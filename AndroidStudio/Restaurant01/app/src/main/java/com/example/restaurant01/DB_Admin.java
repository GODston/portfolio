package com.example.restaurant01;

public class DB_Admin {
    private String Usuario;
    private String Codigo;
    private String Activo;

    public DB_Admin() {
    }

    public DB_Admin(String usuario, String codigo, String activo) {
        Usuario = usuario;
        Codigo = codigo;
        Activo = activo;
    }

    public String getUsuario() {
        return Usuario;
    }

    public void setUsuario(String usuario) {
        Usuario = usuario;
    }

    public String getCodigo() {
        return Codigo;
    }

    public void setCodigo(String codigo) {
        Codigo = codigo;
    }

    public String getActivo() {
        return Activo;
    }

    public void setActivo(String activo) {
        Activo = activo;
    }
}
