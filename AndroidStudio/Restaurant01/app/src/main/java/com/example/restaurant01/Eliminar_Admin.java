package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

public class Eliminar_Admin extends AppCompatActivity {

    TextView txt_cod, txt_usr;
    String cod, usr;
    DatabaseReference DBRef;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_eliminar__admin);

        DBRef = FirebaseDatabase.getInstance().getReference().child("Admin");

        txt_cod = findViewById(R.id.txt_cod);
        txt_usr = findViewById(R.id.txt_usr);
    }

    public void Home(View view){
        Intent i = new Intent(this, Menu_Admin.class);
        startActivity(i);
    }

    public void Eliminar(View view)
    {
        cod = txt_cod.getText().toString();
        usr = txt_usr.getText().toString();

        DBRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(dataSnapshot.child(cod).exists())
                {
                    if(dataSnapshot.child(cod).child("usuario").getValue().toString().equals(usr))
                    {
                        DBRef.child(cod).setValue(null);
                        Toast.makeText(Eliminar_Admin.this, "Se eliminó el perfil de Administrador con éxito.", Toast.LENGTH_LONG).show();
                    }
                    else
                    {
                        txt_usr.setError("El usuario no coincide con el código ingresado.");
                    }
                }
                else
                {
                    Toast.makeText(Eliminar_Admin.this, "Los datos ingresador no son correctos, favor de volver a intentarlo.", Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }
}
