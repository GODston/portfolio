package com.example.restaurant01;

public class DB_Img {

    private String Name;
    private String Url;

    public DB_Img() {
    }

    public DB_Img(String name, String url) {

        if(name.trim().equals(""))
        {
            name = "No name";
        }

        Name = name;
        Url = url;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getUrl() {
        return Url;
    }

    public void setUrl(String url) {
        Url = url;
    }
}
