package com.example.restaurant01;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.ContentResolver;
import android.content.Intent;
import android.content.UriMatcher;
import android.net.Uri;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.View;
import android.webkit.MimeTypeMap;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.OnProgressListener;
import com.google.firebase.storage.StorageReference;
import com.google.firebase.storage.UploadTask;
import com.squareup.picasso.Picasso;

public class Editar_Platillo_Menu extends AppCompatActivity {

    private static final int PICK_IMAGE_REQUEST = 5;
    DatabaseReference DBRef;
    StorageReference STRef;
    boolean cambTitulo, cambDescripcion, cambPrecio, cambImagen, Progress;
    boolean cambió = false;
    boolean caradio = false;
    EditText Titulo, Descripcion, Precio;
    ImageView Imagen;
    Uri Img;
    FirebaseAuth mAuth = FirebaseAuth.getInstance();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_editar__platillo__menu);

        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);
        DBRef = FirebaseDatabase.getInstance().getReference().child("Menu");
        STRef = FirebaseStorage.getInstance().getReference("Platillos");

        Titulo = findViewById(R.id.txt_Title);
        Descripcion = findViewById(R.id.txt_Descripcion);
        Precio = findViewById(R.id.txt_Precio);
        Imagen = findViewById(R.id.Imagen_PLAT);

        int w = dm.widthPixels;
        int h = dm.heightPixels;

        getWindow().setLayout((int)(w*.8), (int)(h*.85));

        cambDescripcion = cambImagen = cambPrecio = cambTitulo = Progress = false;
    }

    @Override
    protected void onStart() {
        super.onStart();
        mAuth.signInAnonymously().addOnSuccessListener(this, new OnSuccessListener<AuthResult>() {
            @Override public void onSuccess(AuthResult authResult) {
                Intent i = getIntent();

                Titulo.setHint(i.getStringExtra(Adapter_Menu_Admins.EXTRA_PLATILLO_Edit));
                Descripcion.setHint(i.getStringExtra(Adapter_Menu_Admins.EXTRA_DESCRIPCION_Edit));
                Precio.setHint(i.getStringExtra(Adapter_Menu_Admins.EXTRA_PRECIO_Edit));
                DBRef.addValueEventListener(new ValueEventListener() {
                    @Override
                    public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                        if(dataSnapshot.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).exists())
                        {
                            if(!dataSnapshot.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).child("Imagen").getValue().toString().equals("null") && !cambió)
                            {
                                Picasso.get().load(dataSnapshot.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).child("Imagen").getValue().toString()).into(Imagen);
                            }
                        }
                    }

                    @Override
                    public void onCancelled(@NonNull DatabaseError databaseError) {

                    }
                });
            }
        }) .addOnFailureListener(this, new OnFailureListener() {
            @Override public void onFailure(@NonNull Exception exception) {
            }
        });

    }

    public String getFileExt(Uri uri){
        ContentResolver cr = getContentResolver();
        MimeTypeMap mime = MimeTypeMap.getSingleton();
        return mime.getExtensionFromMimeType(cr.getType(uri));
    }

    public void Editar(View view)
    {
        Intent i = getIntent();
        caradio = false;

        DBRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {

                if (!caradio) {
                    if (Titulo.getText().toString().length() != 0) {
                        cambTitulo = true;
                    }
                    if (Descripcion.getText().toString().length() != 0) {
                        cambDescripcion = true;
                    }
                    if (Precio.getText().toString().length() != 0) {
                        cambPrecio = true;
                    }
                    if (Img != null) {
                        cambImagen = true;
                    }

                    String msg = "";
                    boolean error = false;
                    if (cambTitulo) {
                        if (Titulo.getText().length() < 3) {
                            Titulo.setError("El Titulo debe contener al menor 3 caracteres.");
                            error = true;
                        }
                    }
                    if (cambDescripcion) {
                        if (Titulo.getText().length() < 3) {
                            Descripcion.setError("El Titulo debe contener al menor 5 caracteres.");
                            error = true;
                        }
                    }
                    if (cambPrecio) {
                        if (Precio.getText().length() < 1) {
                            Descripcion.setError("El Titulo debe contener al menor 1 caracteres.");
                            error = true;
                        }
                    }
                    if (Progress) {
                        error = true;
                        Toast.makeText(Editar_Platillo_Menu.this, "Accion en progreso.", Toast.LENGTH_LONG).show();
                    }

                    if (dataSnapshot.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).exists() && !error) {
                        if (cambTitulo) {
                            DBRef.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).child("Titulo").setValue(Titulo.getText().toString());
                            msg = msg + " ->Titulo";
                        }
                        if (cambPrecio) {
                            DBRef.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).child("Precio").setValue(Precio.getText().toString());
                            msg = msg + " ->Descripcion";
                        }
                        if (cambDescripcion) {
                            DBRef.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).child("Descripcion").setValue(Descripcion.getText().toString());
                            msg = msg + " ->Precio";
                        }
                        if (cambImagen) {
                            msg = msg + "->Imagen";
                            StorageReference filereference = STRef.child(System.currentTimeMillis() + "." + getFileExt(Img));
                            filereference.putFile(Img).addOnSuccessListener(new OnSuccessListener<UploadTask.TaskSnapshot>() {
                                @Override
                                public void onSuccess(UploadTask.TaskSnapshot taskSnapshot) {
                                    Progress = false;
                                    Task<Uri> result = taskSnapshot.getStorage().getDownloadUrl();
                                    result.addOnSuccessListener(new OnSuccessListener<Uri>() {
                                        @Override
                                        public void onSuccess(Uri uri) {
                                            DBRef.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).child("Imagen").setValue(uri.toString());
                                            Picasso.get().load(dataSnapshot.child(i.getStringExtra(Adapter_Menu_Admins.EXTRA_IDPLATILLO_Edit)).child("Imagen").getValue().toString()).into(Imagen);
                                            caradio = true;
                                        }
                                    });
                                }
                            })
                            .addOnFailureListener(new OnFailureListener() {
                                @Override
                                public void onFailure(@NonNull Exception e) {
                                    Progress = false;
                                    Toast.makeText(Editar_Platillo_Menu.this, e.getMessage(), Toast.LENGTH_SHORT).show();
                                }
                            })
                            .addOnProgressListener(new OnProgressListener<UploadTask.TaskSnapshot>() {
                                @Override
                                public void onProgress(@NonNull UploadTask.TaskSnapshot taskSnapshot) {
                                    Progress = true;
                                }
                            });
                        }
                        Toast.makeText(Editar_Platillo_Menu.this, "Se modificó " + msg + ".", Toast.LENGTH_LONG).show();
                        Editar_Platillo_Menu.this.finish();
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });
    }

    public void OpenFileChooser(View view)
    {
        Intent i = new Intent();
        i.setType("image/*");
        i.setAction(i.ACTION_GET_CONTENT);
        startActivityForResult(i, PICK_IMAGE_REQUEST);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if(requestCode == PICK_IMAGE_REQUEST && resultCode == RESULT_OK && data != null && data.getData() != null)
        {
            cambió = true;
            Img = data.getData();
            Picasso.get().load(Img).into(Imagen);
        }
    }
}
