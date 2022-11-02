package com.example.restaurant01;

public class DB_Cuenta {
    private String Cantidad;
    private String Comentario;
    private String Platillo;
    private String Identificador;


    public DB_Cuenta() {
    }

    public DB_Cuenta(String cantidad, String comentario, String platillo, String identificador) {
        Cantidad = cantidad;
        Comentario = comentario;
        Platillo = platillo;
        Identificador = identificador;
    }

    public String getCantidad() {
        return Cantidad;
    }

    public void setCantidad(String cantidad) {
        Cantidad = cantidad;
    }

    public String getComentario() {
        return Comentario;
    }

    public void setComentario(String comentario) {
        Comentario = comentario;
    }

    public String getPlatillo() {
        return Platillo;
    }

    public void setPlatillo(String platillo) {
        Platillo = platillo;
    }

    public String getIdentificador() {
        return Identificador;
    }

    public void setIdentificador(String identificador) {
        Identificador = identificador;
    }
}

