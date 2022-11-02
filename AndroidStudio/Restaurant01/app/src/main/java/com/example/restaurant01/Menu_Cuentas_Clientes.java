package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class Menu_Cuentas_Clientes extends AppCompatActivity {

    RecyclerView rv;
    List<DB_Cuenta> pedidos;
    Adapter_Cuentas_Clientes adapter;
    TextView tiempo, estatus, total;
    Button siguiente;
    DatabaseReference DBRefCnt, DBRefDt, DBRefG;
    Boolean sig = false;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu__cuentas__clientes);

        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);

        int w = dm.widthPixels;
        int h = dm.heightPixels;

        getWindow().setLayout((int)(w*.9), (int)(h*.9));

        rv = (RecyclerView) findViewById(R.id.rv_Clientes_Cuentas);
        pedidos = new ArrayList<>();
        adapter = new Adapter_Cuentas_Clientes(pedidos);
        rv.setLayoutManager(new LinearLayoutManager(this));
        rv.setAdapter(adapter);
        tiempo = findViewById(R.id.txt_Tiempo_Cliente_Menu);
        estatus = findViewById(R.id.txt_Estatus_Clientes);
        total = findViewById(R.id.txt_total_Client);
        siguiente = findViewById(R.id.btn_Sig_Client_Cuenta);

        DBRefCnt = FirebaseDatabase.getInstance().getReference().child("Cuenta").child("" + Select_Mesa.M);
        DBRefDt = FirebaseDatabase.getInstance().getReference().child("DatosCuenta").child("" + Select_Mesa.M);
        DBRefG = FirebaseDatabase.getInstance().getReference();

        DBRefCnt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                pedidos.removeAll(pedidos);
                for(DataSnapshot ds : dataSnapshot.getChildren()){
                    DB_Cuenta db_cuenta = dataSnapshot.child(ds.getKey()).getValue(DB_Cuenta.class);
                    pedidos.add(db_cuenta);
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

        sig = true;
        DBRefDt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                total.setText("$"+ dataSnapshot.child("Total").getValue().toString());
                estatus.setText("Estatus: " + dataSnapshot.child("Estatus").getValue().toString());

                int h, ha, m, ma;
                h = Integer.parseInt(dataSnapshot.child("Hora").getValue().toString());
                m = Integer.parseInt(dataSnapshot.child("Minuto").getValue().toString());

                Calendar time = Calendar.getInstance();

                ha = time.get(Calendar.HOUR_OF_DAY);
                ma = time.get(Calendar.MINUTE);

                tiempo.setText("Tiempo de Espera: " + (ha - h) + ":" + (ma - m));
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    public void Siguiente (View view){
        sig = true;
        DBRefDt.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(sig) {
                    if (dataSnapshot.child("Estatus").getValue().toString().equals("Vacio")) {
                        Toast.makeText(Menu_Cuentas_Clientes.this, "El administrador ha cerrado tu cuenta, reinicia la aplicación para crear una nueva.", Toast.LENGTH_LONG).show();
                    } else if (dataSnapshot.child("Estatus").getValue().toString().equals("Mesa ocupada")) {
                        DBRefDt.child("Estatus").setValue("En espera");
                        Toast.makeText(Menu_Cuentas_Clientes.this, "El administrador ya puede ver su cuenta, cuando sus platillos comiencen a ser preparados su estatus pasará a ser *Preparando Platillos*. Aun puede agregar pedidos a su cuenta.", Toast.LENGTH_LONG).show();
                    } else if (dataSnapshot.child("Estatus").getValue().toString().equals("Preparando Platillos")) {
                        Intent i = new Intent(Menu_Cuentas_Clientes.this, PopUp_TarjetaOEfectivo.class);
                        startActivity(i);
                    } else {
                        Toast.makeText(Menu_Cuentas_Clientes.this, "Por favor espere la respuesta del Administrador.", Toast.LENGTH_LONG).show();
                    }
                    sig = false;
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }
}
