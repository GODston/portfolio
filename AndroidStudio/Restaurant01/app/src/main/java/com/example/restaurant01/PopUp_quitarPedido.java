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

public class PopUp_quitarPedido extends AppCompatActivity {

    DatabaseReference DBRef;
    String cod, total, cant, precio;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pop_up_quitar_pedido);

        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);
        DBRef = FirebaseDatabase.getInstance().getReference();

        int w = dm.widthPixels;
        int h = dm.heightPixels;

        getWindow().setLayout((int)(w*.7), (int)(h*.3));
    }

    @Override
    protected void onStart() {
        super.onStart();

        Intent i = getIntent();
        TextView platillo;
        platillo = findViewById(R.id.txt_platillo5);
        platillo.setText(i.getStringExtra(Adapter_Cuentas_Clientes.EXTRA_PLATILLO));
        cod = i.getStringExtra(Adapter_Cuentas_Clientes.EXTRA_IDPLATILLO);
    }

    public void quitar(View view){
        DBRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                if(!cod.equals("0")) {
                    total = dataSnapshot.child("DatosCuenta").child("" + Select_Mesa.M).child("Total").getValue().toString();
                    cant = dataSnapshot.child("Cuenta").child("" + Select_Mesa.M).child(cod).child("Cantidad").getValue().toString();
                    precio = dataSnapshot.child("Menu").child(dataSnapshot.child("Cuenta").child("" + Select_Mesa.M).child(cod).child("Platillo").getValue().toString()).child("Precio").getValue().toString();
                    float ta = Float.parseFloat(total);
                    float tot = 0;
                    if(ta != 0) {
                        float tt = Integer.parseInt(cant) * Integer.parseInt(precio);
                        tot = ta - tt;
                    }
                    DBRef.child("DatosCuenta").child("" + Select_Mesa.M).child("Total").setValue("" + tot);
                    DBRef.child("Cuenta").child("" + Select_Mesa.M).child(cod).setValue(null);
                    Toast.makeText(PopUp_quitarPedido.this, "Se eliminó el Pedido de la cuenta con éxito.", Toast.LENGTH_LONG).show();
                    cod = "0";
                    PopUp_quitarPedido.this.finish();
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }
}
