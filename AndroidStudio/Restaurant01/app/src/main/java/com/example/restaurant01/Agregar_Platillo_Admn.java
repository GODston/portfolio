package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;
import com.squareup.picasso.Picasso;

public class Agregar_Platillo_Admn extends AppCompatActivity {

    DatabaseReference DBRef;
    TextView Titulo, Descripcion, Precio;
    DB_Platillo db_platillo;
    boolean encontrado = false;
    boolean todocool = true;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_agregar__platillo__admn);

        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);
        DBRef = FirebaseDatabase.getInstance().getReference().child("Menu");

        int w = dm.widthPixels;
        int h = dm.heightPixels;

        getWindow().setLayout((int)(w*.8), (int)(h*.8));
    }

    @Override
    protected void onStart() {
        super.onStart();

        Titulo = findViewById(R.id.t_Titulo);
        Descripcion = findViewById(R.id.t_Descripcion);
        Precio = findViewById(R.id.t_Precio);
    }

    public void Agregar(View view)
    {
        todocool = true;
        if(Titulo.getText().toString().length() < 3)
        {
            Titulo.setError("El titulo debe contener al menos 3 caracteres.");
            todocool = false;
        }
        if(Descripcion.getText().toString().length() < 3)
        {
            Descripcion.setError("La descripción debe contener al menos 3 caracteres.");
            todocool = false;
        }
        if(Precio.getText().toString().length() < 1)
        {
            Precio.setError("El precio debe contener al menos 1 caractér.");
            todocool = false;
        }
        if(todocool)
        {
            DBRef.addValueEventListener(new ValueEventListener() {
                @Override
                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                    for (int i = 1; i < 30; i++) {
                        if (!dataSnapshot.child("" + i).exists() && !encontrado) {
                            encontrado = true;
                            db_platillo = new DB_Platillo(Titulo.getText().toString(), Descripcion.getText().toString(), Precio.getText().toString(), "" + i, "null");
                            DBRef.child("" + i).child("Titulo").setValue(db_platillo.getTitulo());
                            DBRef.child("" + i).child("Descripcion").setValue(db_platillo.getDescripcion());
                            DBRef.child("" + i).child("Precio").setValue(db_platillo.getPrecio());
                            DBRef.child("" + i).child("Imagen").setValue("null");
                            DBRef.child("" + i).child("Identificador").setValue("" + i);
                            Toast.makeText(Agregar_Platillo_Admn.this, "Se agregó el platillo con exito.", Toast.LENGTH_LONG).show();
                            break;
                        }
                    }
                    if (!encontrado) {
                        Toast.makeText(Agregar_Platillo_Admn.this, "Se alcanzó el numero máximo de platillos en la base de datos.", Toast.LENGTH_LONG).show();
                    }
                }

                @Override
                public void onCancelled(@NonNull DatabaseError databaseError) {

                }
            });
            Agregar_Platillo_Admn.this.finish();
        }
    }
}
