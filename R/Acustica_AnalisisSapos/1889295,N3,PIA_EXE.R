library(shiny)
library(seewave)
library(audio)
library(tuneR)
library(vegan)

options(shiny.maxRequestSize = 30*1024^2)

##CONSTANTES
duration <- 30
minfAT <- 1200
maxfAT <- 1800
minfSP <- 2100
maxfSP <- 3000
minfGF <- 1500
maxfGF <- 2200

ui<-fluidPage(
  
  tags$head(tags$style(
    HTML('
             #sidebar {
                background-color: #67b5db;
            }

            #Panel {
                background-color: #f8a8ff;
            }

            body, label, input, button, select { 
            font-family: "Arial";
            }')
  )),
  
  
  titlePanel(
    h1("Proyecto Integrador - Analizdor de llamados de anfibios", align = "center")
  ),
  
  
  sidebarLayout(
    
    
    sidebarPanel(id="sidebar",
                 
                 fluidRow(
                   selectInput(inputId = "ModeSelect",
                               h3("Seleccionar modo"),
                               choices=list("Carga de datos","Ejecutar Analisis"))
                 ),
                 
                 uiOutput("mode"),
                 
    ),
    
    mainPanel(
      id="Panel",
      h3("Rangos de Frecuencia de las especies analizadas"),
      textOutput("rangeAT"),
      textOutput("rangeSP"),
      textOutput("rangeGF"),
      h3("Resultados graficos"),
      tableOutput("name1"),
      textOutput("colorAT"),
      textOutput("colorSP"),
      textOutput("colorGF"),
      plotOutput("plot1"),
      textOutput("TDUR_AT"),
      textOutput("TDUR_SP"),
      textOutput("TDUR_GF"),
      textOutput("LOUD_AT"),
      textOutput("LOUD_SP"),
      textOutput("LOUD_GF"),
      textOutput("CALL_AT"),
      textOutput("CALL_SP"),
      textOutput("CALL_GF"),
      textOutput("STNR_AT"),
      textOutput("STNR_SP"),
      textOutput("STNR_GF"),
      tableOutput("name2"),
      plotOutput("plot2"),
      tableOutput("name3"),
      plotOutput("plot3"),
    )
    
  ))


server <- function(input,output){
  
  counter <- reactiveValues(n = "")
  
  data<-reactive({
    readWave(input$Audio$datapath)
  })
  
  dataAT<-reactive({
    readWave(input$AudioAT$datapath)
  })
  
  dataSP<-reactive({
    readWave(input$AudioSP$datapath)
  })
  
  dataGF<-reactive({
    readWave(input$AudioGF$datapath)
  })
  
  observeEvent(input$btnIniciar,{
    
    output$name<-renderTable({
      input$Audio
    })
    
    DUR_AT <- 0
    DUR_SP <- 0
    DUR_GF <- 0
    LOUD_AT <- 0
    LOUD_SP <- 0
    LOUD_GF <- 0
    CALLR_AT <- 0
    CALLR_SP <- 0
    CALLR_GF <- 0
    SNR_AT <- 0
    SNR_SP <- 0
    SNR_GF <- 0
    
    output$plot1<-renderPlot({
      indx<-input$Indices
      
      ##CODIGO DE ANALISIS
      #Segmentado de audio
      segmentos = list()
      sound_length <- round(length(data()@left) / data()@samp.rate, 2)
      cantsegm <- round(sound_length / duration)
      mxtime <- duration * cantsegm
      start_times = seq(0, mxtime, by = duration)
      
      for (i in seq_along(start_times)) {
        segmentos[[i]] = readWave(input$Audio$datapath,
                                  from = start_times[i],
                                  to = start_times[i] + duration,
                                  units = "seconds")
      }
      
      #Calcular caracteristicas de los bins
      spectrograma <- spec(data(), plot = FALSE)
      idmax <- which.max(spectrograma[,1])
      totframes <- spectrograma[idmax, 1]
      cantbins <- ceiling(totframes * 1000) / 2
      maxf <- max(fpeaks(meanspec(data(), plot = FALSE), plot = FALSE)) * 1000
      fbins <- maxf / cantbins
      maxbinAT <- ceiling(maxfAT/fbins)
      maxbinSP <- ceiling(maxfSP/fbins)
      maxbinGF <- ceiling(maxfGF/fbins)
      minbinAT <- floor(minfAT/fbins)
      minbinSP <- floor(minfSP/fbins)
      minbinGF <- floor(minfGF/fbins)
      binrangeAT <- maxbinAT - minbinAT
      binrangeSP <- maxbinSP - minbinSP
      binrangeGF <- maxbinGF - minbinGF
      
      #limpiar segmentos
      cleansegmAT <- list()
      cleansegmSP <- list()
      cleansegmGF <- list()
      dirtysegmAT <- list()
      dirtysegmSP <- list()
      dirtysegmGF <- list()
      for (i in 1:cantsegm) {
        cleansegmAT[[i]] = ffilter(segmentos[[i]], from = minfAT, to = maxfAT, bandpass = TRUE, output = "Wave", listen = FALSE)
        cleansegmSP[[i]] = ffilter(segmentos[[i]], from = minfSP, to = maxfSP, bandpass = TRUE, output = "Wave", listen = FALSE)
        cleansegmGF[[i]] = ffilter(segmentos[[i]], from = minfGF, to = maxfGF, bandpass = TRUE, output = "Wave", listen = FALSE)
        dirtysegmAT[[i]] = ffilter(segmentos[[i]], from = minfAT, to = maxfAT, bandpass = FALSE, output = "Wave", listen = FALSE)
        dirtysegmSP[[i]] = ffilter(segmentos[[i]], from = minfSP, to = maxfSP, bandpass = FALSE, output = "Wave", listen = FALSE)
        dirtysegmGF[[i]] = ffilter(segmentos[[i]], from = minfGF, to = maxfGF, bandpass = FALSE, output = "Wave", listen = FALSE)
      }
      
      #Separar bins
      binsAT <- list()
      binsSP <- list()
      binsGF <- list()
      cantbinsAT <- cantsegm * binrangeAT
      cantbinsSP <- cantsegm * binrangeSP
      cantbinsGF <- cantsegm * binrangeGF
      #AT
      cont <- minbinAT
      contcleans <- 1
      for (i in 1:cantbinsAT) {
        binsAT[[i]] = ffilter(cleansegmAT[[contcleans]], from = cont * fbins, to = (cont + 1) * fbins, bandpass = TRUE, output = "Wave", listen = FALSE)
        if(cont < maxbinSP){
          cont <- cont + 1
        } else {
          cont <- minbinAT
          contcleans <- contcleans + 1
        }
      }
      #SP
      cont <- minbinSP
      contcleans <- 1
      for (i in 1:cantbinsSP) {
        binsSP[[i]] = ffilter(cleansegmSP[[contcleans]], from = cont * fbins, to = (cont + 1) * fbins, bandpass = TRUE, output = "Wave", listen = FALSE)
        if(cont < maxbinSP){
          cont <- cont + 1
        } else {
          cont <- minbinSP
          contcleans <- contcleans + 1
        }
      }
      #GF
      cont <- minbinGF
      contcleans <- 1
      for (i in 1:cantbinsGF) {
        binsGF[[i]] = ffilter(cleansegmGF[[contcleans]], from = cont * fbins, to = (cont + 1) * fbins, bandpass = TRUE, output = "Wave", listen = FALSE)
        if(cont < maxbinGF){
          cont <- cont + 1
        } else {
          cont <- minbinGF
          contcleans <- contcleans + 1
        }
      }
      
      #Calculamos indices
      INDEX_AT <- list()
      INDEX_SP <- list()
      INDEX_GF <- list()
      if(indx == "ACI-th"){
        cantindexAT <- cantbinsAT * 2
        cantindexSP <- cantbinsSP * 2
        cantindexGF <- cantbinsGF * 2
        #AT
        for(i in 1:cantindexAT){
          if(i %% 2 == 0){
            INDEX_AT[[i]] <- th(env(binsAT[[i/2]], plot = FALSE))
          } else {
            INDEX_AT[[i]] <- ACI(binsAT[[(i + 1)/2]])
          }
        }
        #SP
        for(i in 1:cantindexSP){
          if(i %% 2 == 0){
            INDEX_SP[[i]] <- th(env(binsSP[[i/2]], plot = FALSE))
          } else {
            INDEX_SP[[i]] <- ACI(binsSP[[(i + 1)/2]])
          }
        }
        #GF
        for(i in 1:cantindexGF){
          if(i %% 2 == 0){
            INDEX_GF[[i]] <- th(env(binsGF[[i/2]], plot = FALSE))
          } else {
            INDEX_GF[[i]] <- ACI(binsGF[[(i + 1)/2]])
          }
        }
      } else if(indx == "ACI"){
        #AT
        for(i in 1:cantbinsAT){
          INDEX_AT[[i]] <- ACI(binsAT[[(i + 1)/2]])
        }
        #SP
        for(i in 1:cantbinsSP){
          INDEX_SP[[i]] <- ACI(binsSP[[(i + 1)/2]])
        }
        #GF
        for(i in 1:cantbinsGF){
          INDEX_GF[[i]] <- ACI(binsGF[[(i + 1)/2]])
        }
      } else {
        #AT
        for(i in 1:cantbinsAT){
          INDEX_AT[[i]] <- th(env(binsAT[[(i + 1)/2]], plot = FALSE))
        }
        #SP
        for(i in 1:cantbinsSP){
          INDEX_SP[[i]] <- th(env(binsSP[[(i + 1)/2]], plot = FALSE))
        }
        #GF
        for(i in 1:cantbinsGF){
          INDEX_GF[[i]] <- th(env(binsGF[[(i + 1)/2]], plot = FALSE))
        }
      }
      
      ##GRAFICACION
      output$colorAT <- renderText({
        outputAT <- "American Toad -> Verde"
      })
      output$colorSP <- renderText({
        outputSP <- "Spring Peeper -> Rojo"
      })
      output$colorGF <- renderText({
        outputGF <- "Grey Treefrog -> Azul"
      })
      
      cantindx <- 1
      if(indx == "ACI-th"){
        cantindx <-2
      }
      mxAT <- matrix(unlist(INDEX_AT), nrow = cantsegm, ncol = binrangeAT * cantindx , byrow = TRUE)
      MDS_AT <- metaMDS(mxAT)
      mxSP <- matrix(unlist(INDEX_SP), nrow = cantsegm, ncol = binrangeSP * cantindx , byrow = TRUE)
      MDS_SP <- metaMDS(mxSP)
      mxGF <- matrix(unlist(INDEX_GF), nrow = cantsegm, ncol = binrangeSP * cantindx , byrow = TRUE)
      MDS_GF <- metaMDS(mxGF)
      
      ordiplot(MDS_AT, type = "n", main = indx)
      orditorp(MDS_AT, display = "species", labels = F, pch = c(16), col = c("green"), cex = 1)
      par(new=TRUE)
      ordiplot(MDS_SP, type = "n", main = indx)
      orditorp(MDS_SP, display = "species", labels = F, pch = c(16), col = c("red"), cex = 1)
      par(new=TRUE)
      ordiplot(MDS_GF, type = "n", main = indx)
      orditorp(MDS_GF, display = "species", labels = F, pch = c(16), col = c("blue"), cex = 1)
      
      ##EXTRACCION DE CARACTERISTICAS
      envAT <- list()
      envSP <- list()
      envGF <- list()
      envAT_NOISE <- list()
      envSP_NOISE <- list()
      envGF_NOISE <- list()
      for(i in 1:cantsegm){
        envAT[[i]] <- env(cleansegmAT[[i]], msmooth = c(4785,90), plot = FALSE)
        envSP[[i]] <- env(cleansegmSP[[i]], msmooth = c(4785,90), plot = FALSE)
        envGF[[i]] <- env(cleansegmGF[[i]], msmooth = c(4785,90), plot = FALSE)
        envAT_NOISE[[i]] <- env(cleansegmAT[[i]], plot = FALSE)
        envSP_NOISE[[i]] <- env(cleansegmSP[[i]], plot = FALSE)
        envGF_NOISE[[i]] <- env(cleansegmGF[[i]], plot = FALSE)
      }
      #Loudness
      loudnessAT <- list()
      loudnessSP <- list()
      loudnessGF <- list()
      mxAmpAT <- list()
      mxAmpSP <- list()
      mxAmpGF <-  list()
      mxAmpAT_NOISE <- list()
      mxAmpSP_NOISE <- list()
      mxAmpGF_NOISE <-  list()
      durAT <- list()
      durSP <- list()
      durGF <- list()
      callrateAT <- list()
      callrateSP <- list()
      callrateGF <- list()
      SNRAT <- list()
      SNRSP <- list()
      SNRGF <- list()
      lim <- 0.2
      for(i in 1:cantsegm){
        #AT
        #Loudness
        loudnessAT[[i]] <- colMeans(envAT[[i]])
        #Total Duration #Call Rate
        callrateAT[[i]] <- 0
        mxAmpAT[[i]] <- max(envAT[[i]])
        mxAmpAT_NOISE[[i]] <- max(envAT_NOISE[[i]])
        currState <- FALSE
        lastState <- FALSE
        ini <- nrow(envAT[[i]]) / 100
        fin <- nrow(envAT[[i]]) / 100
        for(j in 1:nrow(envAT[[i]])){
          lastState <- currState
          if(envAT[[i]][[j]] > mxAmpAT[[i]] * lim){
            currState <- TRUE
            lim <- 0.2
            if(!lastState){
              callrateAT[[i]] <- callrateAT[[i]] + 1
              if(j/100 < ini){
                ini <- j/100
              }
            }
          } else {
            currState = FALSE
            lim <- 0.2
            if(lastState){
              fin <- j/100
            }
          }
        }
        durAT[[i]] <- fin - ini
        #Signal-to-noise Ratio
        SNRAT[[i]] <- abs(mxAmpAT[[i]] - mxAmpAT_NOISE[[i]])
        #SP
        #Loudness
        loudnessSP[[i]] <- colMeans(envSP[[i]])
        #Total Duration #Call Rate
        callrateSP[[i]] <- 0
        mxAmpSP[[i]] <- max(envSP[[i]])
        mxAmpSP_NOISE[[i]] <- max(envSP_NOISE[[i]])
        currState <- FALSE
        lastState <- FALSE
        ini <- nrow(envSP[[i]]) / 100
        fin <- nrow(envSP[[i]]) / 100
        for(j in 1:nrow(envSP[[i]])){
          lastState <- currState
          if(envSP[[i]][[j]] > mxAmpSP[[i]] * lim){
            currState <- TRUE
            lim <- 0.2
            if(!lastState){
              callrateSP[[i]] <- callrateSP[[i]] + 1
              if(j/100 < ini){
                ini <- j/100
              }
            }
          } else {
            currState = FALSE
            lim <- 0.2
            if(lastState){
              fin <- j/100
            }
          }
        }
        durSP[[i]] <- fin - ini
        #Signal-to-noise Ratio
        SNRSP[[i]] <- abs(mxAmpSP[[i]] - mxAmpSP_NOISE[[i]])
        #GF
        #Loudness
        loudnessGF[[i]] <- colMeans(envGF[[i]])
        #Total Duration #Call Rate
        callrateGF[[i]] <- 0
        mxAmpGF[[i]] <- max(envGF[[i]])
        mxAmpGF_NOISE[[i]] <- max(envGF_NOISE[[i]])
        currState <- FALSE
        lastState <- FALSE
        ini <- nrow(envGF[[i]]) / 100
        fin <- nrow(envGF[[i]]) / 100
        for(j in 1:nrow(envGF[[i]])){
          lastState <- currState
          if(envGF[[i]][[j]] > mxAmpGF[[i]] * lim){
            currState <- TRUE
            lim <- 0.2
            if(!lastState){
              callrateGF[[i]] <- callrateGF[[i]] + 1
              if(j/100 < ini){
                ini <- j/100
              }
            }
          } else {
            currState = FALSE
            lim <- 0.2
            if(lastState){
              fin <- j/100
            }
          }
        }
        durGF[[i]] <- fin - ini
        #Signal-to-noise Ratio
        SNRGF[[i]] <- abs(mxAmpGF[[i]] - mxAmpGF_NOISE[[i]])
      }
      
      DUR_AT <- round(colMeans(matrix(unlist(durAT), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      DUR_SP <- round(colMeans(matrix(unlist(durSP), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      DUR_GF <- round(colMeans(matrix(unlist(durGF), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      LOUD_AT <- round(colMeans(matrix(unlist(loudnessAT), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      LOUD_SP <- round(colMeans(matrix(unlist(loudnessSP), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      LOUD_GF <- round(colMeans(matrix(unlist(loudnessGF), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      CALLR_AT <- round(colMeans(matrix(unlist(callrateAT), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      CALLR_SP <- round(colMeans(matrix(unlist(callrateSP), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      CALLR_GF <- round(colMeans(matrix(unlist(callrateGF), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      SNR_AT <- round(colMeans(matrix(unlist(SNRAT), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      SNR_SP <- round(colMeans(matrix(unlist(SNRSP), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      SNR_GF <- round(colMeans(matrix(unlist(SNRGF), ncol = 1, nrow = cantsegm, byrow = TRUE)), digits = 2)
      if(CALLR_AT > 30){
        CALLR_AT <- 30
      }
      if(CALLR_SP > 30){
        CALLR_SP <- 30
      }
      if(CALLR_GF > 30){
        CALLR_GF <- 30
      }
      
      output$TDUR_AT <- renderText({
        output_DURAT <- paste0("Duracion total de American Toad: ",DUR_AT, " segundos")
      })
      
      output$TDUR_SP <- renderText({
        output_DURSP <- paste0("Duracion total de Spring Peeper: ",DUR_SP, " segundos")
      })
      
      output$TDUR_GF <- renderText({
        output_DURGF <- paste0("Duracion total de Grey Treefrog: ",DUR_GF, " segundos")
      })
      
      output$LOUD_AT <- renderText({
        output_LOUD_AT <- paste0("Volumen de American Toad: ",LOUD_AT, " dB")
      })
      
      output$LOUD_SP <- renderText({
        output_LOUD_SP <- paste0("Volumen de Spring Peeper: ",LOUD_SP, " dB")
      })
      
      output$LOUD_GF <- renderText({
        output_LOUD_GF <- paste0("Volumen de Grey Treefrog: ",LOUD_GF, " dB")
      })
      
      output$CALL_AT <- renderText({
        output_CALL_AT <- paste0("Call Rate de American Toad: ",CALLR_AT, " llamados/30 segundos")
      })
      
      output$CALL_SP <- renderText({
        output_CALL_SP <- paste0("Call Rate de Spring Peeper: ",CALLR_SP, " llamados/30 segundos")
      })
      
      output$CALL_GF <- renderText({
        output_CALL_GF <- paste0("Call Rate de Grey Treefrog: ",CALLR_GF, " llamados/30 segundos")
      })
      
      output$STNR_AT <- renderText({
        output_STNR_AT <- paste0("Signar to Noise Ratio de American Toad: ",SNR_AT, " dB")
      })
      
      output$STNR_SP <- renderText({
        output_STNR_SP <- paste0("Signar to Noise Rate de Spring Peeper: ",SNR_SP, " dB")
      })
      
      output$STNR_GF <- renderText({
        output_STNR_GF <- paste0("Signar to Noise Rate de Grey Treefrog: ",SNR_GF, " dB")
      })
      
    })
    
  })
  
  #Cargar Audios
  observeEvent(input$btnCargar,{
    
    output$name1<-renderTable({
      input$AudioAT
    })
    
    output$name2<-renderTable({
      input$AudioSP
    })
    
    output$name3<-renderTable({
      input$AudioGF
    })
    
    output$plot1<-renderPlot({
      aAT <- autoc(dataAT(), ylim=c(1,10))
    })
    
    output$plot2<-renderPlot({
      aSP <- autoc(dataSP(), ylim=c(1,10))
    })
    
    output$plot3<-renderPlot({
      aGF <- autoc(dataGF(), ylim=c(1,10))
    })
  })
  
  observeEvent(input$ModeSelect,{
    counter$n <- input$ModeSelect
  })
  
  #OPLAY UDIOS
  observeEvent(input$playAT,{
    fAT <- ffilter(dataAT(), from = (input$mnfAT * 1000), to = (input$mxfAT * 1000), bandpass = TRUE, output = "Wave", listen = TRUE)
  })
  
  observeEvent(input$playSP,{
    fSP <- ffilter(dataAT(), from = (input$mnfAT * 1000), to = (input$mxfAT * 1000), bandpass = TRUE, output = "Wave", listen = TRUE)
  })
  
  observeEvent(input$playGF,{
    fGF <- ffilter(dataGF(), from = (input$mnfAT * 1000), to = (input$mxfAT * 1000), bandpass = TRUE, output = "Wave", listen = TRUE)
  })
  
  observeEvent(input$loadranges,{
    maxfAT <- (input$mxfAT * 1000)
    minfAT <- (input$mnfAT * 1000)
    maxfSP <- (input$mxfSP * 1000)
    minfSP <- (input$mnfSP * 1000)
    maxfGF <- (input$mxfGF * 1000)
    minfGF <- (input$mnfGF * 1000)
    
    output$rangeAT <- renderText({
      outputAT <- paste0("American Toad: ", minfAT, " Hz - ", maxfAT, " Hz")
    })
    output$rangeSP <- renderText({
      outputSP <- paste0("Spring Peeper: ", minfSP, " Hz - ", maxfSP, " Hz")
    })
    output$rangeGF <- renderText({
      outputGF <- paste0("Grey Treefrog: ", minfGF, " Hz - ", maxfGF, " Hz")
    })
  })
  
  modeui <- reactive({
    
    output$rangeAT <- renderText({
      outputAT <- paste0("American Toad: ", minfAT, " Hz - ", maxfAT, " Hz")
    })
    output$rangeSP <- renderText({
      outputSP <- paste0("Spring Peeper: ", minfSP, " Hz - ", maxfSP, " Hz")
    })
    output$rangeGF <- renderText({
      outputGF <- paste0("Grey Treefrog: ", minfGF, " Hz - ", maxfGF, " Hz")
    })
    
    n <- counter$n
    
    if (n == "Carga de datos") {
      x <- 14
      lapply(seq_len(x), function(i) {
        if(i == 1){
          fluidRow(
            column(6,
                   h4("American Toad"),
                   fileInput(inputId = "AudioAT","",accept = ".wav",buttonLabel="Seleccionar Audio"),)
          )
        }
        else if(i == 2){
          fluidRow(
            column(6,
                   h4("Spring Peeper"),
                   fileInput(inputId = "AudioSP","",accept = ".wav",buttonLabel="Seleccionar Audio"),)
          )
        }
        else if(i == 3){
          fluidRow(
            column(6,
                   h4("Grey Treefrog"),
                   fileInput(inputId = "AudioGF","",accept = ".wav",buttonLabel="Seleccionar Audio"),)
          )
        }
        else if(i == 4){
          fluidRow(
            column(6,
                   actionButton(inputId = "btnCargar","Iniciar Carga de Datos"),)
          )
        }
        else if(i == 5){
          numericInput(inputId = "mxfAT",
                       label = "Maxima Frecuencia (kHz) American Toad", value = 10)
        }
        else if(i == 6){
          numericInput(inputId = "mnfAT",
                       label = "Maxima Frecuencia (kHz) American Toad", value = 0)
        }
        else if(i == 7){
          fluidRow(
            column(6,
                   actionButton(inputId = "playAT","Escuchar American Toad"),)
          )
        }
        else if(i == 8){
          numericInput(inputId = "mxfSP",
                       label = "Maxima Frecuencia (kHz) Spring Peeper", value = 10)
        }
        else if(i == 9){
          numericInput(inputId = "mnfSP",
                       label = "Maxima Frecuencia (kHz) Spring Peeper", value = 0)
        }
        else if(i == 10){
          fluidRow(
            column(6,
                   actionButton(inputId = "playSP","Escuchar Spring Peeper"),)
          )
        }
        else if(i == 11){
          numericInput(inputId = "mxfGF",
                       label = "Maxima Frecuencia (kHz) Grey Treefrog", value = 10)
        }
        else if(i == 12){
          numericInput(inputId = "mnfGF",
                       label = "Maxima Frecuencia (kHz) Grey Treefrog", value = 0)
        }
        else if(i == 13){
          fluidRow(
            column(6,
                   actionButton(inputId = "playGF","Escuchar Grey Treefrog"),)
          )
        }
        else if(i == 14){
          fluidRow(
            column(6,
                   actionButton(inputId = "loadranges","Cargar Rangos"),)
          )
        }
      })
    }
    
    else if (n == "Ejecutar Analisis") {
      x <- 3
      lapply(seq_len(x), function(i) {
        if(i == 1){
          fluidRow(
            column(6,
                   h3("Seleccionar audio"),
                   fileInput(inputId = "Audio","",accept = ".wav",buttonLabel="Seleccionar Audio"),)
          )
        }
        else if(i == 2){
          fluidRow(
            selectInput(inputId = "Indices",
                        h3("Indices"),
                        choices=list("ACI","th", "ACI-th"))
          )
        }
        else if(i == 3){
          fluidRow(
            column(6,
                   actionButton(inputId = "btnIniciar","Iniciar Analisis"),)
          )
        }
      })
    }
  })
  
  output$mode <- renderUI({ modeui() })
  
}

shinyApp(ui=ui,server=server)