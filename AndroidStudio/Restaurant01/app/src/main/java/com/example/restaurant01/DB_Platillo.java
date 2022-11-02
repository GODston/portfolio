package com.example.restaurant01;

public class DB_Platillo {
    private String Titulo;
    private String Descripcion;
    private String Precio;
    private String Identificador;
    private String Imagen;

    public DB_Platillo() {
    }

    public DB_Platillo(String titulo, String descripcion, String precio, String identificador, String imagen) {
        Titulo = titulo;
        Descripcion = descripcion;
        Precio = precio;
        Identificador = identificador;
        Imagen = imagen;
    }

    public String getTitulo() {
        return Titulo;
    }

    public void setTitulo(String titulo) {
        Titulo = titulo;
    }

    public String getDescripcion() {
        return Descripcion;
    }

    public void setDescripcion(String descripcion) {
        Descripcion = descripcion;
    }

    public String getPrecio() {
        return Precio;
    }

    public void setPrecio(String precio) {
        Precio = precio;
    }

    public String getIdentificador() {
        return Identificador;
    }

    public void setIdentificador(String identificador) {
        Identificador = identificador;
    }

    public String getImagen() {
        return Imagen;
    }

    public void setImagen(String imagen) {
        Imagen = imagen;
    }
}
