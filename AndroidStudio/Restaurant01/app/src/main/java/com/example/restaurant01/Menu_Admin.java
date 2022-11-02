package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Calendar;

public class Menu_Admin extends AppCompatActivity {
    private static final String FILE_NAME = "ReporteMensual";
    DatabaseReference DBRef;
    boolean generado = false;
    int Month;
    int Year;
    int Hora;
    FileOutputStream fos;
    String lineSeparator = System.getProperty("line.separator");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu__admin);

        DBRef = FirebaseDatabase.getInstance().getReference();
    }
    public void Admin_Admins(View view){
        Intent i = new Intent(this, Administradores.class);
        startActivity(i);
    }
    public void Admin_Menu(View view){
        Intent i = new Intent(this, Menu_Menu.class);
        startActivity(i);
    }
    public void Admin_Cuentas(View view){
        Intent i = new Intent(this, Menu_Cuentas_Admin.class);
        startActivity(i);
    }

    public void Admin_ReporteMensual (View view){
        generado = false;
        Calendar now = Calendar.getInstance();
        Month = now.get(Calendar.MONTH);
        Year = now.get(Calendar.YEAR);
        Hora = now.get(Calendar.HOUR);

        fos = null;
        lineSeparator = System.getProperty("line.separator");
        DBRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(!generado) {
                    try {
                        fos = openFileOutput(FILE_NAME + "_" + Month + "_" + Year + "_" + Hora + ".txt", MODE_PRIVATE);
                        int contador = 0;
                        String Titulo = "REPORTE MENSUAL";
                        String Fecha = "Mes: " + Month + ", Año: " + Year;
                        fos.write(Titulo.getBytes());
                        fos.write(lineSeparator.getBytes());
                        fos.write(Fecha.getBytes());
                        fos.write(lineSeparator.getBytes());
                        for (DataSnapshot ds : dataSnapshot.child("Reporte").getChildren()) {
                            if (dataSnapshot.child("Reporte").child(ds.getKey()).child("Año").equals("" + Year) && dataSnapshot.child("Reporte").child(ds.getKey()).child("Mes").equals("" + Month)) {
                                contador++;
                                String write = "" + contador + ".- " + dataSnapshot.child("Rpeorte").child(ds.getKey()).child("Dia").getValue().toString() + "/" +
                                        dataSnapshot.child("Rpeorte").child(ds.getKey()).child("Mes").getValue().toString() + "/" +
                                        dataSnapshot.child("Rpeorte").child(ds.getKey()).child("Año").getValue().toString() + ", Mesa: " +
                                        dataSnapshot.child("Rpeorte").child(ds.getKey()).child("Mesa").getValue().toString();
                                fos.write(write.getBytes());
                                fos.write(lineSeparator.getBytes());
                                write = "Estatus: " + dataSnapshot.child("Rpeorte").child(ds.getKey()).child("EstatusDeCierre").getValue().toString();
                                fos.write(write.getBytes());
                                fos.write(lineSeparator.getBytes());
                                String DTR = dataSnapshot.child("Rpeorte").child(ds.getKey()).child("DTR").getValue().toString();
                                int contador2 = 0;
                                for(DataSnapshot ds2 : dataSnapshot.child("DatosRpeorte").child(DTR).getChildren()){
                                    contador2++;
                                    write = "" + contador2 + ".- " + "(" + dataSnapshot.child("DatosReporte").child(DTR).child(ds2.getKey()).child("Cantidad").getValue().toString() + ") " +
                                            dataSnapshot.child("DatosReporte").child(DTR).child(ds2.getKey()).child("Platillo").getValue().toString() +
                                            " - $" + dataSnapshot.child("DatosReporte").child(DTR).child(ds2.getKey()).child("Total").getValue().toString();
                                    fos.write(write.getBytes());
                                    fos.write(lineSeparator.getBytes());
                                    write = "Comentarios: " + dataSnapshot.child("DatosReporte").child(DTR).child(ds2.getKey()).child("Comentario").getValue().toString();
                                    fos.write(write.getBytes());
                                    fos.write(lineSeparator.getBytes());
                                }
                                if(contador2 == 0){
                                    write = "Sin Pedidos.";
                                    fos.write(write.getBytes());
                                    fos.write(lineSeparator.getBytes());
                                }
                            }
                        }
                        if(contador == 0){
                            String sad = "Sin Datos para generar el reporte";
                            fos.write(sad.getBytes());
                        }
                        Toast.makeText(Menu_Admin.this, "El reporte se guardo en la dirección: " + getFilesDir() + "/" + FILE_NAME + "_" + Month + "/" + Year + "_" + Hora + ".txt", Toast.LENGTH_LONG).show();
                        generado = true;
                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }
}
