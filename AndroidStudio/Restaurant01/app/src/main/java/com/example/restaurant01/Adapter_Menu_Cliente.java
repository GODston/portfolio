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

import com.squareup.picasso.Picasso;

import java.util.List;

public class Adapter_Menu_Cliente extends RecyclerView.Adapter<Adapter_Menu_Cliente.Platillos_ViewHolder> {

    public static final String EXTRA_PLATILLO = "com.example.restaurante01.Adapter_Menu_Cliente.EXTRA_PLATILLO";
    public static final String EXTRA_DESCRIPCION = "com.example.restaurante01.Adapter_Menu_Cliente.EXTRA_DESCRIPCION";
    public static final String EXTRA_IDPLATILLO = "com.example.restaurante01.Adapter_Menu_Cliente.EXTRA_IDPLATILLO";
    public static final String EXTRA_PRECIO = "com.example.restaurante01.Adapter_Menu_Cliente.EXTRA_PRECIO";
    public static final String EXTRA_IMAGEN = "com.example.restaurante01.Adapter_Menu_Cliente.EXTRA_IMAGEN";

    List<DB_Platillo> platillos;

    public Adapter_Menu_Cliente(List<DB_Platillo> platillos) {
        this.platillos = platillos;
    }

    @NonNull
    @Override
    public Platillos_ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.rowfiller_menu_clientes, parent, false);
        Adapter_Menu_Cliente.Platillos_ViewHolder VH = new Adapter_Menu_Cliente.Platillos_ViewHolder(v);
        return VH;
    }

    @Override
    public void onBindViewHolder(@NonNull Platillos_ViewHolder holder, int position) {
        DB_Platillo bd_platillo = platillos.get(position);
        holder.Titulo.setText(bd_platillo.getTitulo());
        holder.Descripcion.setText(bd_platillo.getDescripcion());
        holder.Precio.setText("$" + bd_platillo.getPrecio());
        holder.ID.setText(bd_platillo.getIdentificador());
        if(!bd_platillo.getImagen().equals("null")) {
            Picasso.get().load(bd_platillo.getImagen()).into(holder.Foto_Platillo);
        }

        holder.btn_Agregar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(v.getContext(), PopUp_AgregarPlatCuenta.class);
                i.putExtra(EXTRA_PLATILLO, holder.Titulo.getText());
                i.putExtra(EXTRA_DESCRIPCION, holder.Descripcion.getText());
                i.putExtra(EXTRA_IDPLATILLO, holder.ID.getText());
                i.putExtra(EXTRA_PRECIO, bd_platillo.getPrecio());
                i.putExtra(EXTRA_IMAGEN, bd_platillo.getImagen());
                v.getContext().startActivity(i);
            }
        });
    }

    @Override
    public int getItemCount() {
        return platillos.size();
    }

    public class Platillos_ViewHolder extends RecyclerView.ViewHolder{

        TextView Titulo;
        TextView Descripcion;
        TextView Precio;
        TextView ID;
        ImageView Foto_Platillo;
        Button btn_Agregar;

        public Platillos_ViewHolder(@NonNull View itemView) {
            super(itemView);

            Titulo = (TextView) itemView.findViewById(R.id.Plat_Titulo_Client);
            Descripcion = (TextView) itemView.findViewById(R.id.Descripcion_Plat_clnt);
            Precio = (TextView) itemView.findViewById(R.id.Precio_Plat_clnt);
            ID = (TextView) itemView.findViewById(R.id.ID_Plat_clnt);
            Foto_Platillo = (ImageView) itemView.findViewById(R.id.Plat_Image_clnt);
            btn_Agregar = (Button) itemView.findViewById(R.id.btn_AddID);
        }
    }
}
