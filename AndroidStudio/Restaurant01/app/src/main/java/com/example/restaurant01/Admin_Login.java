package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.toolbox.StringRequest;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.InputStream;
import java.io.InputStreamReader;

public class Admin_Login extends AppCompatActivity {

    EditText pass;
    DatabaseReference DBReg;
    boolean exito = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_admin__login);
        DBReg = FirebaseDatabase.getInstance().getReference().child("Admin");
        //get ids
        pass = (EditText) findViewById(R.id.pass_admin);
    }
    public void atras(View view){
        Intent i = new Intent(this, MainActivity.class);
        startActivity(i);
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
        Intent i = new Intent(this, MainActivity.class);
        startActivity(i);
    }

    public void validacion(View view) throws InterruptedException, FileNotFoundException {

        try {
            String Contraseña = pass.getText().toString();
            if (Contraseña.equals("")) {
                pass.setError("El código de administrador no puede estar vacio.");
                return;
            }
            else if(Contraseña.length() <5)
            {
                pass.setError("Los códigos de usuario deben contener al menos 5 caracteres.");
                return;
            }

            //Solo entras ps

            DBReg.addValueEventListener(new ValueEventListener() {
                @Override
                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                    if(dataSnapshot.child(Contraseña).exists())
                    {
                        if(dataSnapshot.child(Contraseña).child("activo").getValue().toString().equals("1"))
                        {
                            Toast.makeText(Admin_Login.this, "Se inició sesión con éxito.", Toast.LENGTH_LONG).show();
                            Intent i = new Intent(Admin_Login.this, Menu_Admin.class);
                            startActivity(i);
                        }
                        else
                        {
                            Toast.makeText(Admin_Login.this, "Los datos ingresados son correctos, pero actualmente el usuario se encuentra inhabilitado, se recomienda contactar a un Administrador.", Toast.LENGTH_LONG).show();
                        }
                    }
                    else
                    {
                        Toast.makeText(Admin_Login.this, "Los datos ingresados no coinciden con ningun Usario.", Toast.LENGTH_LONG).show();
                    }
                }

                @Override
                public void onCancelled(@NonNull DatabaseError databaseError) {
                    Toast.makeText(Admin_Login.this, "Ocurrio un Error.", Toast.LENGTH_LONG).show();
                }
            })     ;
            //Fin
        } catch (Exception e) {
            Log.e("Error", "Error--" + e.getMessage().toString());
            Toast.makeText(Admin_Login.this, "Ocurrio un Error --->  " + e.getMessage().toString(), Toast.LENGTH_LONG).show();
        }
    }

}
