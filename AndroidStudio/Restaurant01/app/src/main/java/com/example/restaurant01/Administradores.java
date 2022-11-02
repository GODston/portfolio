package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.net.LinkAddress;
import android.os.Bundle;
import android.view.View;
import android.widget.Adapter;
import android.widget.LinearLayout;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

public class Administradores extends AppCompatActivity {
    List<DB_Admin> admins;
    RecyclerView recyclerView;
    Adapter_Admins adapter;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_administradores);

        FirebaseDatabase DBRef = FirebaseDatabase.getInstance();
        recyclerView = findViewById(R.id.rv);

        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        admins = new ArrayList<>();

        adapter = new Adapter_Admins(admins);
        recyclerView.setAdapter(adapter);

        DBRef.getReference().getRoot().child("Admin").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                admins.removeAll(admins);
                for(DataSnapshot ds : dataSnapshot.getChildren())
                {
                    DB_Admin db_admin = dataSnapshot.child(ds.getKey()).getValue(DB_Admin.class);
                    admins.add(db_admin);
                }
                adapter.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    @Override
    protected void onStart() {
        super.onStart();
    }

    public void Registrar(View view){
        Intent i = new Intent(this, Registrar_Admin.class);
        startActivity(i);
    }

    public void Eliminar(View view){
        Intent i = new Intent(this, Eliminar_Admin.class);
        startActivity(i);
    }

    public void Home(View view){
        Intent i = new Intent(this, Menu_Admin.class);
        startActivity(i);
    }
}
