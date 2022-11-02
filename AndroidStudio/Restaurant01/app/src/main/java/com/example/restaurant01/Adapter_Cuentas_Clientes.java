package com.example.restaurant01;

import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;
import com.squareup.picasso.Picasso;

import java.util.List;

public class Adapter_Cuentas_Clientes extends RecyclerView.Adapter<Adapter_Cuentas_Clientes.Cuenta_Viewholder> {

    public static final String EXTRA_PLATILLO = "com.example.restaurante01.Adapter_Cuentas_Clientes.EXTRA_PLATILLO";
    public static final String EXTRA_IDPLATILLO = "com.example.restaurante01.Adapter_Cuentas_Clientes.EXTRA_IDPLATILLO";
    public static int P;

    FirebaseDatabase DBRef = FirebaseDatabase.getInstance();
    List<DB_Cuenta> pedidos;

    public Adapter_Cuentas_Clientes(List<DB_Cuenta> pedidos) {
        this.pedidos = pedidos;
    }

    @NonNull
    @Override
    public Cuenta_Viewholder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.rowfiller_cuentas_platillos_cliente, parent, false);
        Adapter_Cuentas_Clientes.Cuenta_Viewholder VH = new Adapter_Cuentas_Clientes.Cuenta_Viewholder(v);
        return VH;
    }

    @Override
    public void onBindViewHolder(@NonNull Cuenta_Viewholder holder, int position) {

        DB_Cuenta db_cuenta = pedidos.get(position);

        holder.Cantidad_Cuenta_Platillo.setText("Cantidad: " + db_cuenta.getCantidad());
        holder.Comentarios_Cuenta_Platillo.setText(db_cuenta.getComentario());

        DBRef.getReference().getRoot().child("Menu").addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                holder.Titulo_Cuenta_Platillo.setText(dataSnapshot.child(db_cuenta.getPlatillo()).child("Titulo").getValue().toString());
                holder.Descripcion_Cuenta_Platillo.setText(dataSnapshot.child(db_cuenta.getPlatillo()).child("Descripcion").getValue().toString());
                holder.ID.setText(db_cuenta.getIdentificador());
                if(!dataSnapshot.child(db_cuenta.getPlatillo()).child("Imagen").getValue().toString().equals("null")) {
                    Picasso.get().load(dataSnapshot.child(db_cuenta.getPlatillo()).child("Imagen").getValue().toString()).into(holder.Img_Cuenta_Platillo);
                }
                holder.quitar.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Intent i = new Intent(v.getContext(), PopUp_quitarPedido.class);
                        i.putExtra(EXTRA_PLATILLO, holder.Titulo_Cuenta_Platillo.getText());
                        i.putExtra(EXTRA_IDPLATILLO, holder.ID.getText());
                        v.getContext().startActivity(i);
                    }
                });
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    @Override
    public int getItemCount() {
        return pedidos.size();
    }

    public class Cuenta_Viewholder extends RecyclerView.ViewHolder{

        ImageView Img_Cuenta_Platillo;
        TextView Titulo_Cuenta_Platillo;
        TextView Descripcion_Cuenta_Platillo;
        TextView Comentarios_Cuenta_Platillo;
        TextView Cantidad_Cuenta_Platillo;
        TextView ID;
        Button quitar;

        public Cuenta_Viewholder(@NonNull View itemView) {
            super(itemView);

            Img_Cuenta_Platillo = (ImageView) itemView.findViewById(R.id.rowfiller_clntcuentas_img_plat);
            Titulo_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_clntcuentas_Titulo_plat);
            Descripcion_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_clntcuentas_Descripcion_plat);
            Comentarios_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_clntcuentas_Comentarios_plat);
            Cantidad_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_clntcuentas_Cantidad_plat);
            ID = (TextView) itemView.findViewById(R.id.rowfiller_clntcuentas_identificadortxt);
            quitar = (Button) itemView.findViewById(R.id.rowfiller_clntcuentas_btn_quitar);
        }
    }

}
