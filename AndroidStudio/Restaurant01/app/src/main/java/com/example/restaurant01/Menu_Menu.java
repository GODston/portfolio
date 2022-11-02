package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

public class Menu_Menu extends AppCompatActivity {

    RecyclerView rv;
    List<DB_Platillo> platillos;
    FirebaseDatabase DBRef;
    Adapter_Menu_Admins adapter;
    public static Activity yo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        yo = this;
        setContentView(R.layout.activity_menu__menu);
        DBRef = FirebaseDatabase.getInstance();
        rv = (RecyclerView) findViewById(R.id.recy_view_menus);
        platillos = new ArrayList<>();
        adapter = new Adapter_Menu_Admins(platillos);

        rv.setLayoutManager(new LinearLayoutManager(this));
        rv.setAdapter(adapter);

        DBRef.getReference().getRoot().child("Menu").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                platillos.removeAll(platillos);
                for(DataSnapshot ds : dataSnapshot.getChildren()){
                    DB_Platillo bd_platillo = dataSnapshot.child(ds.getKey()).getValue(DB_Platillo.class);
                    platillos.add(bd_platillo);
                }
                adapter.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    public void Agregar(View view)
    {
        Intent i = new Intent(this, Agregar_Platillo_Admn.class);
        startActivity(i);
    }

    public static Activity getInstance(){
        return yo;
    }
}
