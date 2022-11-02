package com.example.restaurant01;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.Toast;

import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

public class PopUp_TarjetaOEfectivo extends AppCompatActivity {

    DatabaseReference DBRefDt;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pop_up__tarjeta_o_efectivo);

        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);

        int w = dm.widthPixels;
        int h = dm.heightPixels;

        getWindow().setLayout((int)(w*.8), (int)(h*.35));

        DBRefDt = FirebaseDatabase.getInstance().getReference().child("DatosCuenta").child("" + Select_Mesa.M);
    }

    public void Tarjeta (View view){
        DBRefDt.child("Estatus").setValue("Listo para Pagar (Tarjeta)");
        Toast.makeText(PopUp_TarjetaOEfectivo.this, "Se le ha notificado al administraador, por favor preparese para pagar con Tarjeta.", Toast.LENGTH_LONG).show();
        this.finish();
    }

    public void Efectivo (View view){
        DBRefDt.child("Estatus").setValue("Listo para Pagar (Efectivo)");
        Toast.makeText(PopUp_TarjetaOEfectivo.this, "Se le ha notificado al administraador, por favor preparese para pagar con Efectivo.", Toast.LENGTH_LONG).show();
        this.finish();
    }

    public void Ambos (View view){
        DBRefDt.child("Estatus").setValue("Listo para Pagar (Tarjeto y Efectivo)");
        Toast.makeText(PopUp_TarjetaOEfectivo.this, "Se le ha notificado al administraador, por favor preparese para pagar con Tarjeta y Efectivo.", Toast.LENGTH_LONG).show();
        this.finish();
    }
}
