//Giriş Kontrol
function giris() {
    var kullanici_id = $("#kullanici_id").val();
    var kullanici_sifre = $("#kullanici_sifre").val();
    $.ajax({
        type: "post",
        url: "/Home/Login",
        data: { kullanici_id: kullanici_id, kullanici_sifre: kullanici_sifre },
        success: function (datax) {
            if (datax == "") {

            }
            if (datax == "basarili") {
                window.location.href = "/Home/Index";
            }
            else if (datax == "admin") {
                window.location.href = "/Admin/index";
            }
            else if (datax == "basarisiz") {

                document.getElementById('msg').style.display = 'block'
            }

        }
    });
}
//Search
function myFunction() {
    var input, filter, table, tr, td, td1, i, txtValue, txtValue1;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        td1 = tr[i].getElementsByTagName("td")[2];
        if (td) {
            txtValue = td.textContent || td.innerText;
            txtValue1 = td1.textContent || td1.innerText
            if (txtValue.toUpperCase().indexOf(filter) > -1 || txtValue1.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function myFunction1() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
//ürün siler
function silurun(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Admin/UrunSil/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                alert("Silindi");
                var a = "#" + data;
                $(a).remove();
            }
        });
    }
}
//ürün özelliklerini çağır
function urunozellikleri(id) {
    $("#ozellikleralani").find("tr").remove();
    $.ajax({
        url: '/Admin/UrunOzellikleriCagir/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.length == 0) {
                $('#ozellikleralani').append('<tr><td>YOK</td></tr>');
            }
            else {
                $('#ozellikleralani').append('<tr > <th style="width:20%;">ÖZELLİK ADI</th> <th style="width:20%;"> ÖZELLİĞİ</th><th style="width:20%;"></th></tr>');
                $.each(data, function (index) {
                    if (data[index] != "") {
                        var item = data[index].urun_ozellikadi;
                        var item1 = data[index].urun_ozellik;
                        var item2 = data[index].urun_ozellikid;
                        $('#ozellikleralani').append('<tr id="' + item2 + '"><td>' + item + '</td><td>' + item1 + '</td><td><button onclick="ozelliksil(' + item2 + ')" class="sil" >&times; SİL</button></td></tr>');
                    }
                });
            }
            document.getElementById('id01').style.display = 'block';
        }
    });

}

function ozelliksil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Admin/UrunOzellikSil/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                alert("Silindi");
                var a = "#" + data;
                $(a).remove();
            }
        });
    }
}
//Eklenecek özelliğe ait ürün idyi ekler
function ozellikekleurun(id) {
    document.getElementById('formkazanim').style.display = 'block';
    $("input#urun_id").val(id);
}
//ürüne ait özellik ekler
function ozellikekle() {
    var urun_id = $("input#urun_id").val();
    var urun_ozellikadi = $("select#urun_ozellikadi").val();
    var urun_ozellikadi1 = $("input#urun_ozellikadi1").val();
    var urun_ozellik = $("input#urun_ozellik").val();
    if (urun_ozellikadi1.length > 0) {
        urun_ozellikadi = urun_ozellikadi1;
    }
    $.ajax({
        url: '/Admin/UrunOzelligiEkle',
        type: 'POST',
        dataType: 'json',
        data: { urun_id: urun_id, urun_ozellikadi: urun_ozellikadi, urun_ozellik: urun_ozellik },
        success: function () {
            alert("Özellik Eklendi");
        }
    })
}

//sepete ekle
function sepeteekle(id) {
    $.ajax({
        url: '/Home/sepeteekle/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data == "ekli") {
                $("#sepetalani").text("ÜRÜN ZATEN EKLENMİŞ");
                document.getElementById("sepetmodal").style.display = "block";
            }
            else {
                $("#sepetmiktari").text(data);
                $("#sepetalani").text("ÜRÜN SEPETE EKLENDİ");
                document.getElementById("sepetmodal").style.display = "block";
            }
        }
    });
}

//ürünincelemek için id parametresi alır
function urunincele(id) {
    $.ajax({
        url: '/Home/IncelenecekUrunId/' + id,
        type: 'POST',
        dataType: 'json',
        success: function () {
            window.location.href = "/Home/UrunIncele";
        }
    })
}


//sepetteki ürün siler
function silsepeturun(silinenurun) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/SepettekiUrunuSil/' + silinenurun,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                alert("Silindi");
                var a = "div#" + data;
                $(a).remove();
                window.location.reload();
            }
        });
    }
}

//karşılaştırma listesi
function karsilastir(id) {

    $.ajax({
        url: '/Home/Karsilastir/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data == "ekli") {
                $("#karsilastirmaalani").text("Ürün Karşılaştırmaya Zaten Eklenmiş");
                document.getElementById("karsilastir").style.display = "block";
            }
            else if (data == "dolu") {
                $("#karsilastirmaalani").text("Dolu! Karşilaştırmaya En Fazla 4 Ürün Seçilebilir.");
                document.getElementById("karsilastir").style.display = "block";
            }
            else {
                $("#karsilastirmaalani").text("Ürün Karşılaştırmaya Eklendi");
                document.getElementById("karsilastir").style.display = "block";
            }
        }
    });
}
//karşılaştırma listesinde ürünü silme 
function karsilastirsil(id) {
    if (confirm("Kaldırmak istediğinize emin misiniz?")) {
        $.ajax({
            url: '/Home/KarsilastirmaSilme/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                window.location.reload();
            }
        });

    }
}
//Üye Ol
function uyeol() {
    var kullanici_id = $("#kullanici_id").val();
    var kullanici_sifre = $("#kullanici_sifre").val();
    var kullanici_sifretekrar = $("#kullanici_sifretekrar").val();
    var kullanici_adi = $("#kullanici_adi").val();
    var kullanici_soyadi = $("#kullanici_soyadi").val();
    var kullanici_ceptel = $("#kullanici_ceptel").val();
    document.getElementById('kullaniciadimessage').style.display = 'none';
    document.getElementById('sifremessage').style.display = 'none';
    if (kullanici_id == null || kullanici_sifre == null || kullanici_sifretekrar == null || kullanici_adi == null || kullanici_soyadi == null || kullanici_ceptel == null) {

    }
    else {
        if (kullanici_sifre == kullanici_sifretekrar) {
            $.ajax({
                type: "post",
                url: "/Home/KullaniciKayit",
                data: { kullanici_id: kullanici_id, kullanici_sifre: kullanici_sifre, kullanici_adi: kullanici_adi, kullanici_soyadi: kullanici_soyadi },
                success: function (datax) {
                    if (datax == "bulundu") {
                        document.getElementById('kullaniciadimessage').style.display = 'block';
                    }
                    else {
                        document.getElementById('kullaniciadimessage').style.display = 'none';
                        document.getElementById('sifremessage').style.display = 'none';
                        alert("Kullanıcı Kaydedildi! Giriş Yapınız");
                        window.location('Home/GirisYap');
                    }
                }
            });
        }
        else if (kullanici_sifre != kullanici_sifretekrar) {
            document.getElementById('sifremessage').style.display = 'block';
        }
    }
}

function guncellebilgiler(id) {
    var kullanici_id = $("#kullanici_id").val();
    var kullanici_sifre = $("#kullanici_sifre").val();
    var kullanici_adi = $("#kullanici_adi").val();
    var kullanici_soyadi = $("#kullanici_soyadi").val();
    var kullanici_ceptel = $("#kullanici_ceptel").val();
    if (kullanici_id == null || kullanici_sifre == null || kullanici_sifretekrar == null || kullanici_adi == null || kullanici_soyadi == null || kullanici_ceptel == null) {

    }
    else {
        $.ajax({
            type: "post",
            url: "/Home/KullaniciDuzenle",
            data: { kullanici_id: kullanici_id, kullanici_sifre: kullanici_sifre, kullanici_adi: kullanici_adi, kullanici_soyadi: kullanici_soyadi, id: id },
            success: function () {
                alert("Düzenlendi");
                window.location.reload();
            }
        });
    }
}

//Sipariş edilen ürünleri çağırır
function siparisurunleri(id) {
    $("#urunleralani").find("tr").remove();
    $.ajax({
        url: '/Home/SiparisUrunleriCagir/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            if (data.length == 0) {
                $('#urunleralani').append('<tr><td>YOK</td></tr>');
            }
            else {
                $('#urunleralani').append('<tr >  <th style="width:20%;"> Markası</th><th style="width:20%;">Modeli</th><th style="width:20%;">Fiyat</th><th style="width:20%;"></th></tr>');
                $.each(data, function (index) {
                    if (data[index] != "") {
                        var item = data[index].urun_resim;
                        var item1 = data[index].urun_markaadi;
                        var item2 = data[index].urun_modeladi;
                        if (data[index].urun_indirimfiyati == "null") var item3 = data[index].urun_fiyati;
                        else var item3 = data[index].urun_indirimfiyati;
                        var item4 = data[index].urun_id;
                        $('#urunleralani').append('<tr ><td>' + item1 + '</td><td>' + item2 + '</td><td>' + item3 + ' </td><td><button  class="button" onclick="urunincele(' + item4 + ')"  style="color:white">Ürünü İncele</button></td></tr>');
                        //document.getElementById("myImg").src = item;
                    }
                });
            }
            document.getElementById('siparisurunlerimodal').style.display = 'block';
        }
    });
}
//Alışverişi tamamla
function alisverisitamamla() {
    $.ajax({
        url: '/Home/AlisverisiTamamla',
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $("#alisveris_id").text("Sipariş Numaranız=" + data);
            document.getElementById("alisverismsg").style.display = "block";
        }
    });
}
//Hesap Çıkış
function hesapcikis() {
    $.ajax({
        url: '/Home/HesapCikis',
        type: 'POST',
        dataType: 'json',
        success: function () {

        }
    });
}
//Yıldızla
function yildizla(id, urun_id) {
    $.ajax({
        url: '/Home/Yildizla/',
        data: { id: id, urun_id: urun_id },
        type: 'POST',
        dataType: 'json',
        success: function () {
            window.location.reload();
            alert("Ürün Yıldızlandı Puan="+id);
        }
    });
}