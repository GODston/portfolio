package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;


import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.io.BufferedReader;
import java.io.File;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;


public class Registrar_Admin extends AppCompatActivity {

    TextView Nombre, Codigo;
    String codi;
    DatabaseReference DBReg;
    DB_Admin db_admin;
    boolean validar = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registrar__admin);
        DBReg = FirebaseDatabase.getInstance().getReference().child("Admin");
        db_admin = new DB_Admin();

        Nombre = (TextView)findViewById(R.id.Nom_Admin);
        Codigo = (TextView)findViewById(R.id.Cod_Admin);



    }
    public void atras(View view){
        Intent i = new Intent(this, Admin_Login.class);
        startActivity(i);
    }
    public void validacion(View view) throws InterruptedException {
        String nom = Nombre.getText().toString();
        String cod = Codigo.getText().toString();
        codi = cod;

        if(cod.length() < 5)
        {
            Codigo.setError("El Código de administrador deve tener al menos 5 caracteres alfanumericos.");
            return;
        }
        if(nom.length() < 5)
        {
            Nombre.setError("El Nombre de administrador deve tener al menos 5 caracteres alfanumericos.");
            return;
        }
        try {
            db_admin.setUsuario(nom);
            db_admin.setCodigo(cod);
            db_admin.setActivo("1");

            DBReg.addValueEventListener(new ValueEventListener() {
                @Override
                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                    if(dataSnapshot.child(cod).exists())
                    {
                        Toast.makeText(Registrar_Admin.this, "El codigo ingresado ya esa en uso, favor de intentarlo de nuevo.", Toast.LENGTH_LONG).show();
                    }
                    else
                    {
                        DBReg.child(cod).setValue(db_admin);

                        Toast.makeText(Registrar_Admin.this, "Se registro con exito!", Toast.LENGTH_LONG).show();
                        validar = true;
                        Intent i = new Intent(Registrar_Admin.this, Administradores.class);
                        startActivity(i);
                    }
                }

                @Override
                public void onCancelled(@NonNull DatabaseError databaseError) {
                    Toast.makeText(Registrar_Admin.this, "Ocurrio un Error.", Toast.LENGTH_LONG).show();
                }
            });
        }
        catch(Exception e)
        {
            Log.e("Error", "Error--> " + e.getMessage().toString());
            Toast.makeText(Registrar_Admin.this, "Ocurrio un Error --->  " + e.getMessage().toString(), Toast.LENGTH_LONG).show();
        }


    }
}
