package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.FrameLayout;
import android.widget.TextView;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class Menu_Cliente extends AppCompatActivity {

    TextView Titulo, Total;
    DatabaseReference DBRefM, DBRefC;
    FirebaseDatabase DBRefMM;
    RecyclerView rv;
    List<DB_Platillo> platillos;
    Adapter_Menu_Cliente adapter;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu__cliente);
        rv = (RecyclerView) findViewById(R.id.RV_Cliente_Menu);
        platillos = new ArrayList<>();
        adapter = new Adapter_Menu_Cliente(platillos);

        rv.setLayoutManager(new LinearLayoutManager(this));
        rv.setAdapter(adapter);

        Titulo = findViewById(R.id.MenuTituloCliente);
        Total = findViewById(R.id.Total_Client);

        DBRefMM = FirebaseDatabase.getInstance();
        DBRefM = FirebaseDatabase.getInstance().getReference().child("Mesa").child("" + Select_Mesa.M);
        DBRefC = FirebaseDatabase.getInstance().getReference().child("DatosCuenta").child("" + Select_Mesa.M);

        DBRefMM.getReference().getRoot().child("Menu").addValueEventListener(new ValueEventListener() {
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

    @Override
    protected void onStart() {
        super.onStart();

        Titulo.setText("Mesa " + Select_Mesa.M);
        DBRefM.child("EnUso").setValue("1");

        int ha, ma;

        Calendar time = Calendar.getInstance();

        ha = time.get(Calendar.HOUR_OF_DAY);
        ma = time.get(Calendar.MINUTE);

        DBRefC.child("Hora").setValue("" + ha);
        DBRefC.child("Minuto").setValue("" + ma);

        DBRefC.child("Estatus").setValue("Mesa ocupada");

        DBRefC.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                Total.setText("$" + dataSnapshot.child("Total").getValue().toString());
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();

        DBRefM.child("EnUso").setValue("0");
        DBRefC.child("Hora").setValue("0");
        DBRefC.child("Minuto").setValue("0");

        DBRefC.child("Estatus").setValue("Vacio");
        //borrar datos de la cuenta.
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();

        DBRefM.child("EnUso").setValue("0");
        //borrar datos de la cuenta.
    }

    public void Cuenta_PopUp(View view){
        Intent i = new Intent(Menu_Cliente.this, Menu_Cuentas_Clientes.class);
        startActivity(i);
    }

    public void Bloc (View view){
        Intent i = new Intent(this,  Bloqueo.class);
        startActivity( i );
    }
}
