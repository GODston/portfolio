package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.text.Layout;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class Menu_Cuentas_Admin extends AppCompatActivity {

    RecyclerView rv1, rv2, rv3, rv4;
    List<DB_Cuenta> pedidos1, pedidos2, pedidos3, pedidos4;
    Adapter_Cuentas adapter1, adapter2, adapter3, adapter4;
    TextView Tiempo1, Tiempo2, Tiempo3, Tiempo4;
    TextView Estatus1, Estatus2, Estatus3, Estatus4;
    TextView Total1, Total2, Total3, Total4;
    TextView m1, m2, m3, m4;
    LinearLayout lm1, lm2, lm3, lm4;
    LinearLayout lb1, lb2, lb3, lb4;
    Button Siguiente1, Siguiente2, Siguiente3, Siguiente4;
    Button Cerrar1, Cerrar2, Cerrar3, Cerrar4;
    DatabaseReference DBRefCnt, DBRefDt, DBRefG;
    Boolean sig1, sig2, sig3, sig4 = false;
    int DTR, RP;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu__cuentas__admin);

        rv1 = (RecyclerView) findViewById(R.id.rv_Mesa1);
        rv2 = (RecyclerView) findViewById(R.id.rv_Mesa2);
        rv3 = (RecyclerView) findViewById(R.id.rv_Mesa3);
        rv4 = (RecyclerView) findViewById(R.id.rv_Mesa4);
        pedidos1 = new ArrayList<>();
        pedidos2 = new ArrayList<>();
        pedidos3 = new ArrayList<>();
        pedidos4 = new ArrayList<>();

        adapter1 = new Adapter_Cuentas(pedidos1);
        adapter2 = new Adapter_Cuentas(pedidos2);
        adapter3 = new Adapter_Cuentas(pedidos3);
        adapter4 = new Adapter_Cuentas(pedidos4);

        rv1.setLayoutManager(new LinearLayoutManager(this));
        rv2.setLayoutManager(new LinearLayoutManager(this));
        rv3.setLayoutManager(new LinearLayoutManager(this));
        rv4.setLayoutManager(new LinearLayoutManager(this));

        rv1.setAdapter(adapter1);
        rv2.setAdapter(adapter2);
        rv3.setAdapter(adapter3);
        rv4.setAdapter(adapter4);

        Tiempo1 = findViewById(R.id.txt_Cnt_Admin_TiempoM1);
        Tiempo2 = findViewById(R.id.txt_Cnt_Admin_TiempoM2);
        Tiempo3 = findViewById(R.id.txt_Cnt_Admin_TiempoM3);
        Tiempo4 = findViewById(R.id.txt_Cnt_Admin_TiempoM4);

        Estatus1 = findViewById(R.id.txt_Cnt_Admin_EstatusM1);
        Estatus2 = findViewById(R.id.txt_Cnt_Admin_EstatusM2);
        Estatus3 = findViewById(R.id.txt_Cnt_Admin_EstatusM3);
        Estatus4 = findViewById(R.id.txt_Cnt_Admin_EstatusM4);

        Total1 = findViewById(R.id.txt_Cnt_Admin_TotalM1);
        Total2 = findViewById(R.id.txt_Cnt_Admn_TotalM2);
        Total3 = findViewById(R.id.txt_Cnt_Admn_TotalM3);
        Total4 = findViewById(R.id.txt_Cnt_Admn_TotalM4);

        Siguiente1 = findViewById(R.id.btn_Cnt_Admn_Mesa1_Sig);
        Siguiente2 = findViewById(R.id.btn_Cnt_Admn_Mesa2_Sig);
        Siguiente3 = findViewById(R.id.btn_Cnt_Admn_Mesa3_Sig);
        Siguiente4 = findViewById(R.id.btn_Cnt_Admn_Mesa4_Sig);

        Cerrar1 = findViewById(R.id.btn_Cnt_Admn_Mesa1_CerrarCnt);
        Cerrar2 = findViewById(R.id.btn_Cnt_Admn_Mesa2_CerrarCnt);
        Cerrar3 = findViewById(R.id.btn_Cnt_Admn_Mesa3_CerrarCnt);
        Cerrar4 = findViewById(R.id.btn_Cnt_Admn_Mesa4_CerrarCnt);

        m1 = findViewById(R.id.txt_Cnt_Admin_Mesa1);
        m2 = findViewById(R.id.txt_Cnt_Amdn_Mesa2);
        m3 = findViewById(R.id.txt_Cnt_Admn_Mesa3);
        m4 = findViewById(R.id.txt_Cnt_Admn_Mesa4);

        lm1 = (LinearLayout) findViewById(R.id.txts_estatus_Mesa1);
        lm2 = (LinearLayout) findViewById(R.id.txts_estatus_Mesa2);
        lm3 = (LinearLayout) findViewById(R.id.txts_estatus_Mesa3);
        lm4 = (LinearLayout) findViewById(R.id.txts_estatus_Mesa4);

        lb1 = (LinearLayout) findViewById(R.id.btns_Mesa1);
        lb2 = (LinearLayout) findViewById(R.id.btns_Mesa2);
        lb3 = (LinearLayout) findViewById(R.id.btns_Mesa3);
        lb4 = (LinearLayout) findViewById(R.id.btns_Mesa4);

        DBRefCnt = FirebaseDatabase.getInstance().getReference().child("Cuenta");
        DBRefDt = FirebaseDatabase.getInstance().getReference().child("DatosCuenta");
        DBRefG = FirebaseDatabase.getInstance().getReference();

        DBRefCnt.child("1").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                pedidos1.removeAll(pedidos1);
                for(DataSnapshot ds : dataSnapshot.getChildren()){
                    DB_Cuenta db_cuenta = dataSnapshot.child(ds.getKey()).getValue(DB_Cuenta.class);
                    pedidos1.add(db_cuenta);
                }
                adapter1.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });

        DBRefCnt.child("2").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                pedidos2.removeAll(pedidos2);
                for(DataSnapshot ds : dataSnapshot.getChildren()){
                    DB_Cuenta db_cuenta = dataSnapshot.child(ds.getKey()).getValue(DB_Cuenta.class);
                    pedidos2.add(db_cuenta);
                }
                adapter2.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });

        DBRefCnt.child("3").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                pedidos3.removeAll(pedidos3);
                for(DataSnapshot ds : dataSnapshot.getChildren()){
                    DB_Cuenta db_cuenta = dataSnapshot.child(ds.getKey()).getValue(DB_Cuenta.class);
                    pedidos3.add(db_cuenta);
                }
                adapter3.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });

        DBRefCnt.child("4").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                pedidos4.removeAll(pedidos4);
                for(DataSnapshot ds : dataSnapshot.getChildren()){
                    DB_Cuenta db_cuenta = dataSnapshot.child(ds.getKey()).getValue(DB_Cuenta.class);
                    pedidos4.add(db_cuenta);
                }
                adapter4.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    @Override
    protected void onStart() {
        super.onStart();

        DBRefDt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                /*
                Tiempo1.setText("Tiempo de Espera: " + dataSnapshot.child("1").child("Hora").getValue().toString() + ":" + dataSnapshot.child("1").child("Minuto").getValue().toString());
                Tiempo2.setText("Tiempo de Espera: " + dataSnapshot.child("2").child("Hora").getValue().toString() + ":" + dataSnapshot.child("2").child("Minuto").getValue().toString());
                Tiempo3.setText("Tiempo de Espera: " + dataSnapshot.child("3").child("Hora").getValue().toString() + ":" + dataSnapshot.child("3").child("Minuto").getValue().toString());
                Tiempo4.setText("Tiempo de Espera: " + dataSnapshot.child("4").child("Hora").getValue().toString() + ":" + dataSnapshot.child("4").child("Minuto").getValue().toString());
                 */

                Total1.setText("$"+ dataSnapshot.child("1").child("Total").getValue().toString());
                Total2.setText("$"+ dataSnapshot.child("2").child("Total").getValue().toString());
                Total3.setText("$"+ dataSnapshot.child("3").child("Total").getValue().toString());
                Total4.setText("$"+ dataSnapshot.child("4").child("Total").getValue().toString());

                Estatus1.setText(dataSnapshot.child("1").child("Estatus").getValue().toString());
                Estatus2.setText(dataSnapshot.child("2").child("Estatus").getValue().toString());
                Estatus3.setText(dataSnapshot.child("3").child("Estatus").getValue().toString());
                Estatus4.setText(dataSnapshot.child("4").child("Estatus").getValue().toString());

                if(Estatus1.getText().toString().equals("Vacio") || Estatus1.getText().toString().equals("En Uso"))
                {
                    m1.setVisibility(View.GONE);
                    lm1.setVisibility(LinearLayout.GONE);
                    rv1.setVisibility(RecyclerView.GONE);
                    lb1.setVisibility(LinearLayout.GONE);
                    Total1.setVisibility(View.GONE);
                }
                else
                {
                    m1.setVisibility(View.VISIBLE);
                    lm1.setVisibility(LinearLayout.VISIBLE);
                    rv1.setVisibility(RecyclerView.VISIBLE);
                    lb1.setVisibility(LinearLayout.VISIBLE);
                    Total1.setVisibility(View.VISIBLE);
                }

                if(Estatus2.getText().toString().equals("Vacio") || Estatus2.getText().toString().equals("En Uso"))
                {
                    m2.setVisibility(View.GONE);
                    lm2.setVisibility(LinearLayout.GONE);
                    rv2.setVisibility(RecyclerView.GONE);
                    lb2.setVisibility(LinearLayout.GONE);
                    Total2.setVisibility(View.GONE);
                }
                else
                {
                    m2.setVisibility(View.VISIBLE);
                    lm2.setVisibility(LinearLayout.VISIBLE);
                    rv2.setVisibility(RecyclerView.VISIBLE);
                    lb2.setVisibility(LinearLayout.VISIBLE);
                    Total2.setVisibility(View.VISIBLE);
                }

                if(Estatus3.getText().toString().equals("Vacio") || Estatus3.getText().toString().equals("En Uso"))
                {
                    m3.setVisibility(View.GONE);
                    lm3.setVisibility(LinearLayout.GONE);
                    rv3.setVisibility(RecyclerView.GONE);
                    lb3.setVisibility(LinearLayout.GONE);
                    Total3.setVisibility(View.GONE);
                }
                else
                {
                    m3.setVisibility(View.VISIBLE);
                    lm3.setVisibility(LinearLayout.VISIBLE);
                    rv3.setVisibility(RecyclerView.VISIBLE);
                    lb3.setVisibility(LinearLayout.VISIBLE);
                    Total3.setVisibility(View.VISIBLE);
                }

                if(Estatus4.getText().toString().equals("Vacio") || Estatus4.getText().toString().equals("En Uso"))
                {
                    m4.setVisibility(View.GONE);
                    lm4.setVisibility(LinearLayout.GONE);
                    rv4.setVisibility(RecyclerView.GONE);
                    lb4.setVisibility(LinearLayout.GONE);
                    Total4.setVisibility(View.GONE);
                }
                else
                {
                    m4.setVisibility(View.VISIBLE);
                    lm4.setVisibility(LinearLayout.VISIBLE);
                    rv4.setVisibility(RecyclerView.VISIBLE);
                    lb4.setVisibility(LinearLayout.VISIBLE);
                    Total4.setVisibility(View.VISIBLE);
                }

                Calendar time = Calendar.getInstance();

                int h1, h2, h3, h4, min1, min2, min3, min4;
                int ha, ma;
                h1 = Integer.parseInt(dataSnapshot.child("1").child("Hora").getValue().toString());
                h2 = Integer.parseInt(dataSnapshot.child("2").child("Hora").getValue().toString());
                h3 = Integer.parseInt(dataSnapshot.child("3").child("Hora").getValue().toString());
                h4 = Integer.parseInt(dataSnapshot.child("4").child("Hora").getValue().toString());

                min1 = Integer.parseInt(dataSnapshot.child("1").child("Minuto").getValue().toString());
                min2 = Integer.parseInt(dataSnapshot.child("1").child("Minuto").getValue().toString());
                min3 = Integer.parseInt(dataSnapshot.child("1").child("Minuto").getValue().toString());
                min4 = Integer.parseInt(dataSnapshot.child("1").child("Minuto").getValue().toString());

                ha = time.get(Calendar.HOUR_OF_DAY);
                ma = time.get(Calendar.MINUTE);

                Tiempo1.setText("Tiempo de Espera: " + (ha - h1) + ":" + (ma - min1));
                Tiempo2.setText("Tiempo de Espera: " + (ha - h2) + ":" + (ma - min2));
                Tiempo3.setText("Tiempo de Espera: " + (ha - h3) + ":" + (ma - min3));
                Tiempo4.setText("Tiempo de Espera: " + (ha - h4) + ":" + (ma - min4));
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    public void SiguienteM1 (View view){
        DTR = RP = 0;
        sig1 = true;
        DBRefDt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(sig1){
                    if(dataSnapshot.child("1").child("Estatus").getValue().toString().equals("En espera")){
                        Toast.makeText(Menu_Cuentas_Admin.this, "El estatus de la cuenta ha cambiado.", Toast.LENGTH_LONG).show();
                        DBRefDt.child("1").child("Estatus").setValue("Preparando Platillos");
                        sig1 = false;
                    }
                    else if(dataSnapshot.child("1").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta)") || dataSnapshot.child("1").child("Estatus").getValue().toString().equals("Listo para Pagar (Efectivo)") || dataSnapshot.child("1").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta y Efectivo)")){
                        DBRefG.addValueEventListener(new ValueEventListener() {
                            @Override
                            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                if(sig1){
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("DatosReporte").child("" + i).exists()){
                                            DTR = i;
                                            break;
                                        }
                                    }
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("Reporte").child("" + i).exists()){
                                            RP = i;
                                            break;
                                        }
                                    }
                                }
                            }

                            @Override
                            public void onCancelled(@NonNull DatabaseError databaseError) {

                            }
                        });
                        if(DTR != 0 && RP != 0){
                            Calendar now = Calendar.getInstance();
                            DBRefG.child("Reporte").child("" + RP).child("Año").setValue("" + now.get(Calendar.YEAR));
                            DBRefG.child("Reporte").child("" + RP).child("Mes").setValue("" + now.get(Calendar.MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Dia").setValue("" + now.get(Calendar.DAY_OF_MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Mesa").setValue("1");
                            DBRefG.child("Reporte").child("" + RP).child("DTReporte").setValue("" + DTR);
                            DBRefG.child("Reporte").child("" + RP).child("EstatusDeCierre").setValue("" + dataSnapshot.child("1").child("Estatus").getValue().toString());

                            DBRefG.addValueEventListener(new ValueEventListener() {
                                @Override
                                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                    if(sig1){
                                        for(DataSnapshot ds : dataSnapshot.child("Cuenta").child("1").getChildren()){
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Cantidad").setValue(dataSnapshot.child("Cuenta").child("1").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            float cant = Float.parseFloat(dataSnapshot.child("Cuenta").child("1").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Comentario").setValue(dataSnapshot.child("Cuenta").child("1").child(ds.getKey()).child("Comentario").getValue().toString());
                                            String plat = dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("1").child(ds.getKey()).child("Platillo").getValue().toString()).child("Titulo").getValue().toString();
                                            float precio = Float.parseFloat(dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("1").child(ds.getKey()).child("Platillo").getValue().toString()).child("Precio").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Platillo").setValue(plat);
                                            float total = cant * precio;
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Total").setValue("" + total);
                                        }
                                    }
                                }

                                @Override
                                public void onCancelled(@NonNull DatabaseError databaseError) {

                                }
                            });
                        }

                        Toast.makeText(Menu_Cuentas_Admin.this, "Se ha cerrado la cuenta.", Toast.LENGTH_LONG).show();
                        DBRefG.child("Mesa").child("1").child("EnUso").setValue("0");
                        DBRefDt.child("1").child("Total").setValue("0");
                        DBRefDt.child("1").child("Hora").setValue("0");
                        DBRefDt.child("1").child("Minuto").setValue("0");
                        DBRefDt.child("1").child("Estatus").setValue("Vacio");
                        DBRefCnt.child("1").setValue(null);
                        sig1 = false;
                    }
                    else{
                        Toast.makeText(Menu_Cuentas_Admin.this, "Por favor, espere la respuesta del Cliente.", Toast.LENGTH_LONG).show();
                        sig1 = false;
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });

    }

    public void SiguienteM2 (View view){
        DTR = RP = 0;
        sig2 = true;
        DBRefDt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(sig2){
                    if(dataSnapshot.child("2").child("Estatus").getValue().toString().equals("En espera")){
                        Toast.makeText(Menu_Cuentas_Admin.this, "El estatus de la cuenta ha cambiado.", Toast.LENGTH_LONG).show();
                        DBRefDt.child("2").child("Estatus").setValue("Preparando Platillos");
                        sig2 = false;
                    }
                    else if(dataSnapshot.child("2").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta)") || dataSnapshot.child("2").child("Estatus").getValue().toString().equals("Listo para Pagar (Efectivo)") || dataSnapshot.child("2").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta y Efectivo)")){
                        //Guardar en Reporte
                        DBRefG.addValueEventListener(new ValueEventListener() {
                            @Override
                            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                if(sig2){
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("DatosReporte").child("" + i).exists()){
                                            DTR = i;
                                            break;
                                        }
                                    }
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("Reporte").child("" + i).exists()){
                                            RP = i;
                                            break;
                                        }
                                    }
                                }
                            }

                            @Override
                            public void onCancelled(@NonNull DatabaseError databaseError) {

                            }
                        });
                        if(DTR != 0 && RP != 0){
                            Calendar now = Calendar.getInstance();
                            DBRefG.child("Reporte").child("" + RP).child("Año").setValue("" + now.get(Calendar.YEAR));
                            DBRefG.child("Reporte").child("" + RP).child("Mes").setValue("" + now.get(Calendar.MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Dia").setValue("" + now.get(Calendar.DAY_OF_MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Mesa").setValue("2");
                            DBRefG.child("Reporte").child("" + RP).child("DTReporte").setValue("" + DTR);
                            DBRefG.child("Reporte").child("" + RP).child("EstatusDeCierre").setValue("" + dataSnapshot.child("2").child("Estatus").getValue().toString());

                            DBRefG.addValueEventListener(new ValueEventListener() {
                                @Override
                                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                    if(sig2){
                                        for(DataSnapshot ds : dataSnapshot.child("Cuenta").child("2").getChildren()){
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Cantidad").setValue(dataSnapshot.child("Cuenta").child("2").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            float cant = Float.parseFloat(dataSnapshot.child("Cuenta").child("2").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Comentario").setValue(dataSnapshot.child("Cuenta").child("2").child(ds.getKey()).child("Comentario").getValue().toString());
                                            String plat = dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("2").child(ds.getKey()).child("Platillo").getValue().toString()).child("Titulo").getValue().toString();
                                            float precio = Float.parseFloat(dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("2").child(ds.getKey()).child("Platillo").getValue().toString()).child("Precio").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Platillo").setValue(plat);
                                            float total = cant * precio;
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Total").setValue("" + total);
                                        }
                                    }
                                }

                                @Override
                                public void onCancelled(@NonNull DatabaseError databaseError) {

                                }
                            });
                        }
                        //Fin

                        Toast.makeText(Menu_Cuentas_Admin.this, "Se ha cerrado la cuenta.", Toast.LENGTH_LONG).show();
                        DBRefG.child("Mesa").child("2").child("EnUso").setValue("0");
                        DBRefDt.child("2").child("Total").setValue("0");
                        DBRefDt.child("2").child("Hora").setValue("0");
                        DBRefDt.child("2").child("Minuto").setValue("0");
                        DBRefDt.child("2").child("Estatus").setValue("Vacio");
                        sig2 = false;
                    }
                    else{
                        Toast.makeText(Menu_Cuentas_Admin.this, "Por favor, espere la respuesta del Cliente.", Toast.LENGTH_LONG).show();
                        sig2 = false;
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    public void SiguienteM3 (View view){
        DTR = RP = 0;
        sig3 = true;
        DBRefDt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(sig3){
                    if(dataSnapshot.child("3").child("Estatus").getValue().toString().equals("En espera")){
                        Toast.makeText(Menu_Cuentas_Admin.this, "El estatus de la cuenta ha cambiado.", Toast.LENGTH_LONG).show();
                        DBRefDt.child("3").child("Estatus").setValue("Preparando Platillos");
                        sig3 = false;
                    }
                    else if(dataSnapshot.child("3").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta)") || dataSnapshot.child("3").child("Estatus").getValue().toString().equals("Listo para Pagar (Efectivo)") || dataSnapshot.child("3").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta y Efectivo)")){
                        DBRefG.addValueEventListener(new ValueEventListener() {
                            @Override
                            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                if(sig3){
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("DatosReporte").child("" + i).exists()){
                                            DTR = i;
                                            break;
                                        }
                                    }
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("Reporte").child("" + i).exists()){
                                            RP = i;
                                            break;
                                        }
                                    }
                                }
                            }

                            @Override
                            public void onCancelled(@NonNull DatabaseError databaseError) {

                            }
                        });
                        if(DTR != 0 && RP != 0){
                            Calendar now = Calendar.getInstance();
                            DBRefG.child("Reporte").child("" + RP).child("Año").setValue("" + now.get(Calendar.YEAR));
                            DBRefG.child("Reporte").child("" + RP).child("Mes").setValue("" + now.get(Calendar.MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Dia").setValue("" + now.get(Calendar.DAY_OF_MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Mesa").setValue("3");
                            DBRefG.child("Reporte").child("" + RP).child("DTReporte").setValue("" + DTR);
                            DBRefG.child("Reporte").child("" + RP).child("EstatusDeCierre").setValue("" + dataSnapshot.child("3").child("Estatus").getValue().toString());

                            DBRefG.addValueEventListener(new ValueEventListener() {
                                @Override
                                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                    if(sig3){
                                        for(DataSnapshot ds : dataSnapshot.child("Cuenta").child("3").getChildren()){
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Cantidad").setValue(dataSnapshot.child("Cuenta").child("3").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            float cant = Float.parseFloat(dataSnapshot.child("Cuenta").child("3").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Comentario").setValue(dataSnapshot.child("Cuenta").child("3").child(ds.getKey()).child("Comentario").getValue().toString());
                                            String plat = dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("3").child(ds.getKey()).child("Platillo").getValue().toString()).child("Titulo").getValue().toString();
                                            float precio = Float.parseFloat(dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("3").child(ds.getKey()).child("Platillo").getValue().toString()).child("Precio").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Platillo").setValue(plat);
                                            float total = cant * precio;
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Total").setValue("" + total);
                                        }
                                    }
                                }

                                @Override
                                public void onCancelled(@NonNull DatabaseError databaseError) {

                                }
                            });
                        }

                        Toast.makeText(Menu_Cuentas_Admin.this, "Se ha cerrado la cuenta.", Toast.LENGTH_LONG).show();
                        DBRefG.child("Mesa").child("3").child("EnUso").setValue("0");
                        DBRefDt.child("3").child("Total").setValue("0");
                        DBRefDt.child("3").child("Hora").setValue("0");
                        DBRefDt.child("3").child("Minuto").setValue("0");
                        DBRefDt.child("3").child("Estatus").setValue("Vacio");
                        sig3 = false;
                    }
                    else{
                        Toast.makeText(Menu_Cuentas_Admin.this, "Por favor, espere la respuesta del Cliente.", Toast.LENGTH_LONG).show();
                        sig3 = false;
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });

    }

    public void SiguienteM4 (View view){
        DTR = RP = 0;
        sig4 = true;
        DBRefDt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(sig4){
                    if(dataSnapshot.child("4").child("Estatus").getValue().toString().equals("En espera")){
                        Toast.makeText(Menu_Cuentas_Admin.this, "El estatus de la cuenta ha cambiado.", Toast.LENGTH_LONG).show();
                        DBRefDt.child("4").child("Estatus").setValue("Preparando Platillos");
                        sig4 = false;
                    }
                    else if(dataSnapshot.child("4").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta)") || dataSnapshot.child("4").child("Estatus").getValue().toString().equals("Listo para Pagar (Efectivo)") || dataSnapshot.child("4").child("Estatus").getValue().toString().equals("Listo para Pagar (Tarjeta y Efectivo)")){
                        DBRefG.addValueEventListener(new ValueEventListener() {
                            @Override
                            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                if(sig4){
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("DatosReporte").child("" + i).exists()){
                                            DTR = i;
                                            break;
                                        }
                                    }
                                    for(int i = 1; i < 501; i++){
                                        if(!dataSnapshot.child("Reporte").child("" + i).exists()){
                                            RP = i;
                                            break;
                                        }
                                    }
                                }
                            }

                            @Override
                            public void onCancelled(@NonNull DatabaseError databaseError) {

                            }
                        });
                        if(DTR != 0 && RP != 0){
                            Calendar now = Calendar.getInstance();
                            DBRefG.child("Reporte").child("" + RP).child("Año").setValue("" + now.get(Calendar.YEAR));
                            DBRefG.child("Reporte").child("" + RP).child("Mes").setValue("" + now.get(Calendar.MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Dia").setValue("" + now.get(Calendar.DAY_OF_MONTH));
                            DBRefG.child("Reporte").child("" + RP).child("Mesa").setValue("4");
                            DBRefG.child("Reporte").child("" + RP).child("DTReporte").setValue("" + DTR);
                            DBRefG.child("Reporte").child("" + RP).child("EstatusDeCierre").setValue("" + dataSnapshot.child("4").child("Estatus").getValue().toString());

                            DBRefG.addValueEventListener(new ValueEventListener() {
                                @Override
                                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                    if(sig4){
                                        for(DataSnapshot ds : dataSnapshot.child("Cuenta").child("4").getChildren()){
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Cantidad").setValue(dataSnapshot.child("Cuenta").child("4").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            float cant = Float.parseFloat(dataSnapshot.child("Cuenta").child("4").child(ds.getKey()).child("Cantidad").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Comentario").setValue(dataSnapshot.child("Cuenta").child("4").child(ds.getKey()).child("Comentario").getValue().toString());
                                            String plat = dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("4").child(ds.getKey()).child("Platillo").getValue().toString()).child("Titulo").getValue().toString();
                                            float precio = Float.parseFloat(dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("4").child(ds.getKey()).child("Platillo").getValue().toString()).child("Precio").getValue().toString());
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Platillo").setValue(plat);
                                            float total = cant * precio;
                                            DBRefG.child("DatosReporte").child("" + DTR).child(ds.getKey()).child("Total").setValue("" + total);
                                        }
                                    }
                                }

                                @Override
                                public void onCancelled(@NonNull DatabaseError databaseError) {

                                }
                            });
                        }

                        Toast.makeText(Menu_Cuentas_Admin.this, "Se ha cerrado la cuenta.", Toast.LENGTH_LONG).show();
                        DBRefG.child("Mesa").child("4").child("EnUso").setValue("0");
                        DBRefDt.child("4").child("Total").setValue("0");
                        DBRefDt.child("4").child("Hora").setValue("0");
                        DBRefDt.child("4").child("Minuto").setValue("0");
                        DBRefDt.child("4").child("Estatus").setValue("Vacio");
                        sig4 = false;
                    }
                    else{
                        Toast.makeText(Menu_Cuentas_Admin.this, "Por favor, espere la respuesta del Cliente.", Toast.LENGTH_LONG).show();
                        sig4 = false;
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });

    }

    public void CerrarCntM1(View view){
        DBRefDt.child("1").child("Estatus").setValue("Vacio");
        DBRefG.child("Mesa").child("1").child("EnUso").setValue("0");
        DBRefDt.child("1").child("Total").setValue("0");
        DBRefDt.child("1").child("Hora").setValue("0");
        DBRefDt.child("1").child("Minuto").setValue("0");
        DBRefCnt.child("1").setValue(null);
        Toast.makeText(Menu_Cuentas_Admin.this, "Se ha cerrado la cuenta.", Toast.LENGTH_LONG).show();
    }

    public void CerrarCntM2(View view){
        DBRefDt.child("2").child("Estatus").setValue("Vacio");
        DBRefG.child("Mesa").child("2").child("EnUso").setValue("0");
        DBRefDt.child("2").child("Total").setValue("0");
        DBRefDt.child("2").child("Hora").setValue("0");
        DBRefDt.child("2").child("Minuto").setValue("0");
        DBRefCnt.child("2").setValue(null);
        Toast.makeText(Menu_Cuentas_Admin.this, "Se ha cerrado la cuenta.", Toast.LENGTH_LONG).show();
    }

    public void CerrarCntM3(View view){
        DBRefDt.child("3").child("Estatus").setValue("Vacio");
        DBRefG.child("Mesa").child("3").child("EnUso").setValue("0");
        DBRefDt.child("3").child("Total").setValue("0");
        DBRefDt.child("3").child("Hora").setValue("0");
        DBRefDt.child("3").child("Minuto").setValue("0");
        DBRefCnt.child("3").setValue(null);
    }

    public void CerrarCntM4(View view){
        DBRefDt.child("4").child("Estatus").setValue("Vacio");
        DBRefG.child("Mesa").child("4").child("EnUso").setValue("0");
        DBRefDt.child("4").child("Total").setValue("0");
        DBRefDt.child("4").child("Hora").setValue("0");
        DBRefDt.child("4").child("Minuto").setValue("0");
        DBRefCnt.child("4").setValue(null);
        Toast.makeText(Menu_Cuentas_Admin.this, "Se ha cerrado la cuenta.", Toast.LENGTH_LONG).show();
    }
}
