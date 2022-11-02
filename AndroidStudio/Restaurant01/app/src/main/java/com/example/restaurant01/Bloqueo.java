package com.example.restaurant01;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.KeyEvent;
import android.widget.Toast;

public class Bloqueo extends AppCompatActivity {

    private static final int PRESS_INTERVAL = 1000;
    private long upKeyTime = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bloqueo);
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        if (KeyEvent.KEYCODE_VOLUME_DOWN == event.getKeyCode()) {
            if ((event.getEventTime() - upKeyTime) < PRESS_INTERVAL) {
                this.finish();
            }
            return true;
        } else if (keyCode == KeyEvent.KEYCODE_VOLUME_UP) {
            return true;
        }
        return super.onKeyDown(keyCode, event);
    }


    @Override
    public boolean onKeyUp(int keyCode, KeyEvent event) {
        if (KeyEvent.KEYCODE_VOLUME_UP == keyCode) {
            upKeyTime = event.getEventTime();
        }
        return super.onKeyUp(keyCode, event);
    }

    @Override
    public void onBackPressed() {
    }
}
