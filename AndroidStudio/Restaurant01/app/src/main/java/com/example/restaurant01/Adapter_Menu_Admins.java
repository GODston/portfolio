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

public class Adapter_Menu_Admins extends RecyclerView.Adapter<Adapter_Menu_Admins.Platillos_ViewHolder>{
    public static final String EXTRA_PLATILLO = "com.example.restaurante01.Adapter_Menu_Admin.EXTRA_PLATILLO";
    public static final String EXTRA_IDPLATILLO = "com.example.restaurante01.Adapter_Menu_Admin.EXTRA_IDPLATILLO";
    public static final String EXTRA_PLATILLO_Edit = "com.example.restaurante01.Adapter_Menu_Admin.EXTRA_PLATILLO_Edit";
    public static final String EXTRA_IDPLATILLO_Edit = "com.example.restaurante01.Adapter_Menu_Admin.EXTRA_IDPLATILLO_Edit";
    public static final String EXTRA_DESCRIPCION_Edit = "com.example.restaurante01.Adapter_Menu_Admin.EXTRA_DESCRIPCION_Edit";
    public static final String EXTRA_PRECIO_Edit = "com.example.restaurante01.Adapter_Menu_Admin.EXTRA_PRECIO_Edit";
    public static final String EXTRA_ACTIVITY = "com.example.restaurante01.Adapter_Menu_Admin.EXTRA_ACTIVITY";

    List<DB_Platillo> platillos;

    public Adapter_Menu_Admins(List<DB_Platillo> platillos) {
        this.platillos = platillos;
    }

    @NonNull
    @Override
    public Platillos_ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.rowfiller_menu_platillos, parent, false);
        Platillos_ViewHolder VH = new Platillos_ViewHolder(v);
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

        holder.btn_Eliminar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(v.getContext(), Eliminar_Platillo_Menu.class);
                i.putExtra(EXTRA_PLATILLO, holder.Titulo.getText());
                i.putExtra(EXTRA_IDPLATILLO, holder.ID.getText());
                v.getContext().startActivity(i);
            }
        });
        holder.btn_Editar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(v.getContext(), Editar_Platillo_Menu.class);
                i.putExtra(EXTRA_PLATILLO_Edit, holder.Titulo.getText());
                i.putExtra(EXTRA_IDPLATILLO_Edit, holder.ID.getText());
                i.putExtra(EXTRA_DESCRIPCION_Edit, holder.Descripcion.getText());
                i.putExtra(EXTRA_PRECIO_Edit, holder.Precio.getText());
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
        Button btn_Editar;
        Button btn_Eliminar;

        public Platillos_ViewHolder(@NonNull View itemView) {
            super(itemView);

            Titulo = (TextView) itemView.findViewById(R.id.Plat_Titulo_Client);
            Descripcion = (TextView) itemView.findViewById(R.id.Descripcion_Plat_clnt);
            Precio = (TextView) itemView.findViewById(R.id.Precio_Plat_clnt);
            ID = (TextView) itemView.findViewById(R.id.ID_Plat_clnt);
            Foto_Platillo = (ImageView) itemView.findViewById(R.id.Plat_Image_clnt);
            btn_Editar = (Button) itemView.findViewById(R.id.btn_AddID);
            btn_Eliminar = (Button) itemView.findViewById(R.id.btn_ElimID);
        }
    }
}
