package com.example.restaurant01;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }
    public void Admin_login(View view){
        Intent i = new Intent(this, Admin_Login.class);
        startActivity( i );
    }
    public void Select_Menu(View view){
        Intent i = new Intent(this,  Select_Mesa.class);
        startActivity( i );
    }

    public void Bloc (View view){
        Intent i = new Intent(this,  Bloqueo.class);
        startActivity( i );
    }
}
