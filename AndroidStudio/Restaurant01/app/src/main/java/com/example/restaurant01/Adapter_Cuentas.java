package com.example.restaurant01;

import android.media.Image;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
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

public class Adapter_Cuentas extends RecyclerView.Adapter<Adapter_Cuentas.Cuenta_Viewholder> {

    FirebaseDatabase DBRef = FirebaseDatabase.getInstance();
    List<DB_Cuenta> pedidos;

    public Adapter_Cuentas(List<DB_Cuenta> pedidos) {
        this.pedidos = pedidos;
    }

    @NonNull
    @Override
    public Cuenta_Viewholder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.rowfiller_cuentas_platillos, parent, false);
        Adapter_Cuentas.Cuenta_Viewholder VH = new Adapter_Cuentas.Cuenta_Viewholder(v);
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
                    if(!dataSnapshot.child(db_cuenta.getPlatillo()).child("Imagen").getValue().toString().equals("null")) {
                        Picasso.get().load(dataSnapshot.child(db_cuenta.getPlatillo()).child("Imagen").getValue().toString()).into(holder.Img_Cuenta_Platillo);
                    }
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

        public Cuenta_Viewholder(@NonNull View itemView) {
            super(itemView);

            Img_Cuenta_Platillo = (ImageView) itemView.findViewById(R.id.rowfiller_cuentas_img_plat);
            Titulo_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_cuentas_Titulo_plat);
            Descripcion_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_cuentas_Descripcion_plat);
            Comentarios_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_cuentas_Comentarios_plat);
            Cantidad_Cuenta_Platillo = (TextView) itemView.findViewById(R.id.rowfiller_cuentas_Cantidad_plat);
        }
    }
}
