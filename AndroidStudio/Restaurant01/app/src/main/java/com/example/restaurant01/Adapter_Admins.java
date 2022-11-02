package com.example.restaurant01;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class Adapter_Admins extends RecyclerView.Adapter<Adapter_Admins.AdminsViewHolder>{

    List<DB_Admin> admins;

    public Adapter_Admins(List<DB_Admin> admins) {
        this.admins = admins;
    }

    @NonNull
    @Override
    public AdminsViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.rowfiller_admins, parent, false);
        AdminsViewHolder VH = new AdminsViewHolder(v);
        return VH;
    }

    @Override
    public void onBindViewHolder(@NonNull AdminsViewHolder holder, int position) {
        DB_Admin DBadmin = admins.get(position);
        holder.Usuario.setText(DBadmin.getUsuario());
        holder.Activo.setText("Activo: " + DBadmin.getActivo());
        holder.Codigo.setText("Código: " + DBadmin.getCodigo());
    }

    @Override
    public int getItemCount() {
        return admins.size();
    }

    public static class AdminsViewHolder extends RecyclerView.ViewHolder{

        TextView Usuario, Activo, Codigo;

        public AdminsViewHolder(@NonNull View itemView) {
            super(itemView);
            Activo = (TextView) itemView.findViewById(R.id.CH_Admin_Activo);
            Codigo = (TextView) itemView.findViewById(R.id.CH_Admin_Codigo);
            Usuario = (TextView) itemView.findViewById(R.id.CH_Admin_Usr);
        }
    }
}
