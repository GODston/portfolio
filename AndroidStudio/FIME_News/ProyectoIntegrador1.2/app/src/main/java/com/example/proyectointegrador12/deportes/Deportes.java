package com.example.proyectointegrador12.deportes;

import android.content.Intent;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;

import com.example.proyectointegrador12.EditNoticia;
import com.example.proyectointegrador12.MenuDinamico;
import com.example.proyectointegrador12.R;
import com.example.proyectointegrador12.adapters.Adapter_Principal;
import com.example.proyectointegrador12.db.DB_Noticias;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

public class Deportes extends Fragment {

    public static final String USUARIO = "com.example.proyectointegrador12.deportes.Deportes.USUARIO";

    FirebaseDatabase DBRef;
    RecyclerView rv; //rv
    Adapter_Principal adapter;
    List<DB_Noticias> noticias;
    LinearLayout ll_add;

    String TipoUsr = "", idUsr = "";

    boolean onload = false;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_deportes, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        //DB
        DBRef = FirebaseDatabase.getInstance();

        MenuDinamico MD = (MenuDinamico) getActivity();
        TipoUsr = MD.getTipoUsr();
        idUsr = MD.getUsr();

        //UI
        noticias = new ArrayList<>();
        rv = view.findViewById(R.id.rv_Deportes);
        adapter = new Adapter_Principal(noticias, TipoUsr, idUsr);
        ll_add = view.findViewById(R.id.ll_add_D);

        //Hide
        if(TipoUsr.equals("1")){
            ll_add.setVisibility(view.GONE);
        }

        //Rexicler View
        rv.setLayoutManager(new LinearLayoutManager(getContext()));
        rv.setAdapter(adapter);

        //Content
        onload = true;
        DBRef.getReference().getRoot().child("Noticias").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                noticias.removeAll(noticias);
                for (DataSnapshot ds : dataSnapshot.getChildren()) {
                    if (ds.child("contenido").exists() && ds.child("fecha").exists() && ds.child("id_Noticia").exists() && ds.child("id_Usr").exists() && ds.child("imagen").exists() &&
                            ds.child("tipo_Noticia").exists() && ds.child("titulo").exists()){
                        if (ds.child("tipo_Noticia").getValue().toString().equals("3")) {
                            DB_Noticias db_noticias = dataSnapshot.child(ds.getKey()).getValue(DB_Noticias.class);
                            noticias.add(db_noticias);
                        }
                    }
                }
                adapter.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    public void add(View view) {
        Intent i = new Intent(this.getContext(), EditNoticia.class);
        startActivity(i);
    }
}