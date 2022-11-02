package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

public class Select_Mesa extends AppCompatActivity {

    public static final String EXTRA_MESA = "com.example.restaurante01.Select_Mesa.EXTRA_MESA";

    DatabaseReference DBRef;
    ImageView mesa1, mesa2, mesa3, mesa4;
    boolean m1, m2, m3, m4;
    public static  int M;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_select__mesa);

        DBRef = FirebaseDatabase.getInstance().getReference().child("Mesa");

        mesa1 = findViewById(R.id.img_Mesa1);
        mesa2 = findViewById(R.id.img_Mesa2);
        mesa3 = findViewById(R.id.img_Mesa3);
        mesa4 = findViewById(R.id.img_Mesa4);

        DBRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(dataSnapshot.child("1").child("EnUso").getValue().toString().equals("1")){
                    mesa1.setAlpha((float) 0.4);
                    m1 = false;
                }
                else
                {
                    mesa1.setAlpha((float) 1);
                    m1 = true;
                }
                if(dataSnapshot.child("2").child("EnUso").getValue().toString().equals("1")){
                    mesa2.setAlpha((float) 0.4);
                    m2 = false;
                }
                else
                {
                    mesa2.setAlpha((float) 1);
                    m2 = true;
                }
                if(dataSnapshot.child("3").child("EnUso").getValue().toString().equals("1")){
                    mesa3.setAlpha((float) 0.4);
                    m3 = false;
                }
                else
                {
                    mesa3.setAlpha((float) 1);
                    m3 = true;
                }
                if(dataSnapshot.child("4").child("EnUso").getValue().toString().equals("1")){
                    mesa4.setAlpha((float) 0.4);
                    m4 = false;
                }
                else
                {
                    mesa4.setAlpha((float) 1);
                    m4 = true;
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }
    public void Atras(View view){
        Intent i = new Intent(this, MainActivity.class);
        startActivity(i);
    }
    public void Mesa1(View view){
        if(m1){
            Entrar(1);
        }
        else
        {
            Toast.makeText(Select_Mesa.this, "La mesa ya esta en uso.", Toast.LENGTH_SHORT).show();
        }
    }
    public void Mesa2(View view){
        if(m2){
            Entrar(2);
        }
        else
        {
            Toast.makeText(Select_Mesa.this, "La mesa ya esta en uso.", Toast.LENGTH_SHORT).show();
        }
    }
    public void Mesa3(View view){
        if(m3){
            Entrar(3);
        }
        else
        {
            Toast.makeText(Select_Mesa.this, "La mesa ya esta en uso.", Toast.LENGTH_SHORT).show();
        }
    }
    public void Mesa4(View view){
        if(m4){
            Entrar(4);
        }
        else
        {
            Toast.makeText(Select_Mesa.this, "La mesa ya esta en uso.", Toast.LENGTH_SHORT).show();
        }
    }

    public void Entrar(int mesa)
    {
        M = mesa;
        Intent i = new Intent(this, Menu_Cliente.class);
        startActivity(i);
    }

    @Override
    protected void onStart() {
        super.onStart();


    }

    public void Bloc (View view){
        Intent i = new Intent(this,  Bloqueo.class);
        startActivity( i );
    }
}
