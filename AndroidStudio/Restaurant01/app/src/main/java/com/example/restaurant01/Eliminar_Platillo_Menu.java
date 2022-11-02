package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
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

public class Eliminar_Platillo_Menu extends AppCompatActivity {

    DatabaseReference DBRef;
    String cod;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_eliminar__platillo__menu);

        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);
        DBRef = FirebaseDatabase.getInstance().getReference().child("Menu");

        int w = dm.widthPixels;
        int h = dm.heightPixels;

        getWindow().setLayout((int)(w*.7), (int)(h*.3));
    }

    @Override
    protected void onStart() {
        super.onStart();

        Intent i = getIntent();
        TextView platillo;
        platillo = findViewById(R.id.txt_platillo);
        platillo.setText(i.getStringExtra(Adapter_Menu_Admins.EXTRA_PLATILLO));
        cod = i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO);
    }

    public void Eliminar(View view)
    {

        DBRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(cod != "0") {
                    DBRef.child(cod).setValue(null);
                    cod = "0";
                    Toast.makeText(Eliminar_Platillo_Menu.this, "Se eliminó el Platillo del Menú con éxito.", Toast.LENGTH_LONG).show();
                    Eliminar_Platillo_Menu.this.finish();
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }
}
