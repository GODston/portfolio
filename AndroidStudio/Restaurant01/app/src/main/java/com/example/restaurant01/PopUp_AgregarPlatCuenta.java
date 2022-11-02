package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.common.data.DataBufferRef;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;
import com.squareup.picasso.Picasso;

public class PopUp_AgregarPlatCuenta extends AppCompatActivity {

    TextView Titulo, Descripcion, Identificador, Precio;
    EditText Comentario, Cantidad;
    ImageView Imagen;
    Button Agregar, mas, menos;
    Float Total, tot;
    int cant;
    Intent i;
    boolean guardado, g2;

    DatabaseReference DBrefC, DBrefDC;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pop_up__agregar_plat_cuenta);

        DBrefC = FirebaseDatabase.getInstance().getReference().child("Cuenta").child("" + Select_Mesa.M);
        DBrefDC = FirebaseDatabase.getInstance().getReference().child("DatosCuenta").child("" + Select_Mesa.M);
        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);
        i = getIntent();

        int w = dm.widthPixels;
        int h = dm.heightPixels;

        getWindow().setLayout((int)(w*.8), (int)(h*.9));

        Titulo = findViewById(R.id.Titulo_Plat_Add_clnt);
        Descripcion = findViewById(R.id.Descripcion_Plat_Add_clnt);
        Identificador = findViewById(R.id.ADD_Identificador_Platillo_clnt);
        Precio = findViewById(R.id.Precio_Plat_ADD_clnt);
        Comentario = findViewById(R.id.txt_Coments_Add_Plat_clnt);
        Cantidad = findViewById(R.id.txt_cant_plat_add_clnt);
        Imagen = findViewById(R.id.IMG_Plat_Add_clnt);
        Agregar = findViewById(R.id.btn_ADD);
        mas = findViewById(R.id.btn_MAS);
        menos = findViewById(R.id.btn_MENOS);
    }

    @Override
    protected void onStart() {
        super.onStart();

        Total = (float)0;

        Titulo.setText(i.getStringExtra(Adapter_Menu_Cliente.EXTRA_PLATILLO));
        Identificador.setText(i.getStringExtra(Adapter_Menu_Cliente.EXTRA_IDPLATILLO));
        Descripcion.setText(i.getStringExtra(Adapter_Menu_Cliente.EXTRA_DESCRIPCION));
        cant = 1;
        Cantidad.setText("" + cant);
        Total = Float.parseFloat(i.getStringExtra(Adapter_Menu_Cliente.EXTRA_PRECIO)) * cant;
        Precio.setText("$" + Total);
        Picasso.get().load(i.getStringExtra(Adapter_Menu_Cliente.EXTRA_IMAGEN)).into(Imagen);
    }

    public void Mas(View view){
        cant++;
        Cantidad.setText("" + cant);
        Total = Float.parseFloat(i.getStringExtra(Adapter_Menu_Cliente.EXTRA_PRECIO))* cant;
        Precio.setText("$" + Total);
    }

    public void Menos(View view){
        if(Cantidad.getText().length() != 0 && Integer.parseInt(Cantidad.getText().toString()) > 0) {
            cant--;
            Cantidad.setText("" + cant);
            Total = Float.parseFloat(i.getStringExtra(Adapter_Menu_Cliente.EXTRA_PRECIO)) * cant;
            Precio.setText("$" + Total);
        }
    }

    public void Agregar_btn(View view){
        guardado = false;
        g2 = false;
        if(cant > 0) {
            DBrefC.addValueEventListener(new ValueEventListener() {
                @Override
                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                    for(int i = 1; i < 30; i++)
                    {
                        if(!dataSnapshot.child("" + i).exists() && !guardado)
                        {
                            DBrefC.child("" + i).child("Platillo").setValue(Identificador.getText());
                            if(Comentario.getText().length() != 0) {
                                DBrefC.child("" + i).child("Comentario").setValue(Comentario.getText().toString());
                            }else{
                                DBrefC.child("" + i).child("Comentario").setValue("Sin Comentarios.");
                            }
                            DBrefC.child("" + i).child("Cantidad").setValue("" + cant);
                            DBrefC.child("" + i).child("Identificador").setValue("" + i);
                            guardado = true;
                            Toast.makeText(PopUp_AgregarPlatCuenta.this, "Se agrego el Pedido a tu Cuenta.", Toast.LENGTH_SHORT).show();
                            break;
                        }
                    }
                    if(!guardado)
                    {
                        Toast.makeText(PopUp_AgregarPlatCuenta.this, "Se alcanzó el limite de pedidos por cuenta.", Toast.LENGTH_SHORT).show();
                    }
                    PopUp_AgregarPlatCuenta.this.finish();
                }

                @Override
                public void onCancelled(@NonNull DatabaseError databaseError) {

                }
            });

            DBrefDC.addValueEventListener(new ValueEventListener() {
                @Override
                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                    if(!g2)
                    {
                        tot = Float.parseFloat(dataSnapshot.child("Total").getValue().toString()) + Total;
                        DBrefDC.child("Total").setValue("" + tot);
                        g2 = true;
                    }
                }

                @Override
                public void onCancelled(@NonNull DatabaseError databaseError) {

                }
            });
        }
        else
        {
            Cantidad.setError("La cantidad debe ser mayor a 0.");
        }
    }
}
