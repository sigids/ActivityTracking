# Dokumen Spesifikasi Aplikasi Analisis Beban Kerja Staf Admin

**Tanggal:** 24 Mei 2024
**Versi:** 1.0

---

### 1. Pendahuluan

Dokumen ini menjelaskan spesifikasi teknis dan fungsional untuk pengembangan aplikasi **Analisis Beban Kerja Staf Admin Produksi dan QC**. Aplikasi ini bertujuan untuk menggantikan proses manual pencatatan aktivitas harian staf yang menggunakan komputer. Dengan aplikasi ini, data dapat dikumpulkan secara terstruktur, dianalisis, dan diolah menjadi laporan-laporan serta Key Performance Indicator (KPI) yang berguna untuk manajemen dalam mengukur efektivitas, efisiensi, dan distribusi beban kerja.

### 2. Tujuan Aplikasi

Berdasarkan draft yang diberikan, tujuan utama aplikasi ini adalah:
-   **Merekam Data Aktivitas:** Menyediakan antarmuka (web form) bagi staf admin untuk mencatat setiap aktivitas komputer mereka secara harian, sesuai dengan format yang telah ditentukan.
-   **Menghasilkan Laporan Ringkasan:** Menyajikan data ringkasan per hari, minggu, atau bulan, seperti total waktu aktivitas, total aktivitas, dan aktivitas yang paling dominan.
-   **Menghitung dan Menampilkan KPI:** Menghitung secara otomatis berbagai KPI yang telah didefinisikan untuk mengevaluasi performa dan produktivitas, seperti persentase waktu efektif, rasio aktivitas manual/komputerisasi, dan variasi beban kerja.
-   **Mengidentifikasi Area Peningkatan:** Memberikan data yang dapat ditindaklanjuti untuk mengurangi aktivitas manual, mengidentifikasi aktivitas berulang yang bisa diotomasi, dan menilai pemanfaatan sistem yang ada (seperti DTS dan Stage/Proman).

### 3. Teknologi yang Digunakan

-   **Frontend Framework:** .NET 9 ASP.NET Blazor (Blazor Web App direkomendasikan untuk fleksibilitas deployment).
-   **Backend Framework:** .NET 9 ASP.NET Core Web API (untuk logika bisnis dan akses data).
-   **Database:** Microsoft SQL Server (MSSQL).

### 4. Arsitektur Aplikasi

Aplikasi akan dibangun dengan arsitektur berlapis (N-Tier Architecture) untuk memisahkan tanggung jawab dan memudahkan pemeliharaan:

1.  **Presentation Layer (Frontend):** Menggunakan **Blazor Web App**. Layer ini bertanggung jawab untuk menampilkan UI (User Interface) yang interaktif kepada pengguna (staf admin dan manajer). Komponen Blazor akan mengkonsumsi data dari Backend API.
2.  **Business Logic Layer (Backend):** Menggunakan **ASP.NET Core Web API**. Layer ini akan menangani semua logika bisnis, seperti validasi data, perhitungan KPI, dan aturan-aturan lainnya. API akan menyediakan *endpoint* yang dapat dipanggil oleh frontend.
3.  **Data Access Layer:** Menggunakan **Entity Framework Core (EF Core)**. Layer ini berfungsi sebagai perantara antara aplikasi dan database MSSQL untuk melakukan operasi CRUD (Create, Read, Update, Delete).
4.  **Database Layer:** **MSSQL Server** untuk menyimpan semua data aktivitas, data pengguna, dan data master.

### 5. Detail Fitur Aplikasi

Aplikasi akan dibagi menjadi beberapa modul utama:

#### Modul 1: Manajemen Pengguna dan Autentikasi

-   **Fitur:**
    -   Halaman Login untuk mengakses aplikasi.
    -   Manajemen Pengguna (hanya untuk Admin):
        -   Registrasi Pengguna Baru (staf admin).
        -   Input data master pengguna: Employee ID, Nama, Jabatan, Bagian, Unit, Tipe Karyawan (Monthly/Daily), Komputer (Dedicated/Shared).
        -   Mengaitkan pengguna dengan data komputer yang digunakan.
    -   Role-Based Access Control (RBAC):
        -   **Role Admin:** Bisa mengakses seluruh fitur, termasuk manajemen pengguna, melihat laporan semua staf, dan mengelola data master.
        -   **Role Staf:** Hanya bisa menginput data aktivitas harian sendiri dan melihat laporan/ringkasan miliknya.

#### Modul 2: Input Data Monitoring Aktivitas Harian (Core Feature)

-   **Fitur:**
    -   Sebuah form berbasis web yang dapat diisi oleh staf setiap hari.
    -   Form ini akan memiliki field sesuai dengan "Detail" pada dokumen (Sheet1, baris 8-19).
-   **Spesifikasi Form:**
    -   **Header Data (Diambil dari data pengguna yang login):**
        -   Employee ID (Auto-fill)
        -   Nama (Auto-fill)
        -   Tanggal (Default: hari ini, dapat diubah)
        -   Jabatan, Bagian, Unit, Tipe Karyawan, Komputer (Auto-fill)
    -   **Tabel Input Aktivitas:**
        -   Pengguna dapat menambahkan beberapa baris aktivitas dalam satu hari.
        -   Kolom yang harus diisi untuk setiap baris:
            -   `No` (Auto-increment di UI).
            -   `Komputer No`: Pilihan dropdown (jika staf menggunakan lebih dari satu komputer).
            -   `Aktivitas`: Dropdown dengan pilihan: *Pemasukan Data, Pencocokan Data, Rekap Data, Laporan Data, Buat Data*. (Data master ini harus bisa dikelola oleh Admin).
            -   `Deskripsi Singkat Isi Data`: Textbox (input bebas).
            -   `Digunakan Oleh`: Dropdown (jika data digunakan oleh pihak lain, bisa diisi manual atau dari data master).
            -   `Upload File Hasil / Screen Shoot`: Fitur upload file (image/pdf).
            -   `Waktu Mulai`, `Waktu Selesai`: Input waktu (Time picker).
            -   `Durasi (Mnt/Jam)`: **Dihitung otomatis** dari selisih Waktu Selesai dan Waktu Mulai, tetapi tetap bisa diedit manual.
            -   `Frekuensi`: Dropdown dengan pilihan: *Per Jam, Harian, Mingguan, Bulanan, Insidentil*.
            -   `Metode Kerja`: Dropdown dengan pilihan: *Tulis Tangan, Non Sistem Aplikasi, Email, Sistem Aplikasi, Print*.
            -   `Aplikasi Digunakan`: Dropdown dengan pilihan: *DTS, Stage/Proman, Entahr, Lainnya*. (Data master ini harus bisa dikelola oleh Admin).
            -   `Jenis Dok`, `Nama Dok`, `Asal Dok`: Textbox (input bebas).
            -   `Keterangan`: Textarea (input bebas).
    -   **Tombol Aksi:** "Tambah Baris", "Simpan Data Harian".

#### Modul 3: Laporan dan Analisis (Dashboard)

-   **Fitur:**
    -   Halaman Dashboard yang menampilkan visualisasi data.
    -   Filter untuk menampilkan data: berdasarkan rentang tanggal (harian/mingguan/bulanan), nama staf, bagian, atau unit.
-   **Spesifikasi Laporan:**
    -   **Bagian B: Data Ringkasan**
        -   `Total Waktu Aktivitas`: Jumlah total `Durasi` dari semua aktivitas dalam periode filter.
        -   `Total Aktivitas`: Jumlah baris aktivitas yang diinput dalam periode filter.
        -   `Total Aktivitas Berulang`: Jumlah aktivitas dengan `Frekuensi` bukan "Insidentil".
        -   `Total Aktivitas Komputerisasi`: Jumlah aktivitas dengan `Metode Kerja` = "Sistem Aplikasi".
        -   `Total Aktivitas Manual`: Jumlah aktivitas dengan `Metode Kerja` selain "Sistem Aplikasi".
        -   `Aktivitas Paling Banyak`: Menampilkan `Aktivitas` yang paling sering muncul.
        -   `Aktivitas Paling Lama`: Menampilkan `Aktivitas` dengan total `Durasi` tertinggi.
    -   **Bagian C: KPI**
        -   Setiap KPI akan ditampilkan dalam bentuk kartu atau grafik.
        -   **KPI 1: % Waktu Efektif**
            -   **Formula:** `(Total Waktu Aktivitas (dalam jam) / Total Jam Kerja dalam periode) * 100%`.
            -   **Catatan:** Perlu input master data "Jam Kerja Efektif per Hari" (misal 8 jam).
        -   **KPI 2: % Rasio Aktivitas Manual / Komputerisasi**
            -   **Formula:** `(Total Aktivitas Manual / Total Aktivitas Komputerisasi) * 100%`.
        -   **KPI 3: % Aktivitas Berulang / Total Aktivitas**
            -   **Formula:** `(Total Aktivitas Berulang / Total Aktivitas) * 100%`.
        -   **KPI 4: % Pembuatan Laporan**
            -   **Formula:** `(Jumlah aktivitas 'Laporan Data' / Total Aktivitas) * 100%`.
        -   **KPI 5: % Pemanfaatan Komputer**
            -   **Formula:** `(Total Waktu Aktivitas (dalam menit) / Total Waktu PC Tersedia (dalam menit)) * 100%`.
            -   **Catatan:** "Total Waktu PC Tersedia" = (Jam Kerja Efektif per Hari * 60 menit) * Jumlah Hari Kerja dalam periode.
        -   **KPI 6: Variasi Beban Kerja antar Staf**
            -   **Formula:** `Standard Deviation dari Total Waktu Efektif Kerja per Staf`.
        -   **KPI 7 & 8: Perbandingan Aktivitas Aplikasi**
            -   **Formula:** `(Jumlah aktivitas dengan Aplikasi 'DTS' / Total Aktivitas) * 100%` (untuk KPI 7).
            -   **Formula:** `(Jumlah aktivitas dengan Aplikasi 'Stage/Proman' / Total Aktivitas) * 100%` (untuk KPI 8).

#### Modul 4: Manajemen Data Master (Hanya untuk Admin)

-   **Fitur:**
    -   Halaman untuk mengelola data yang digunakan dalam dropdown di Modul 2.
    -   Ini termasuk:
        -   Master `Aktivitas` (Pemasukan Data, dll.)
        -   Master `Frekuensi` (Per Jam, dll.)
        -   Master `Metode Kerja` (Tulis Tangan, dll.)
        -   Master `Aplikasi Digunakan` (DTS, dll.)
        -   Master `Jenis Dokumen`
    -   Fitur CRUD (Create, Read, Update, Delete) untuk setiap master data.

### 6. Desain Database (Skema Awal)

Berdasarkan fitur di atas, berikut adalah tabel-tabel utama yang perlu dibuat di MSSQL:

1.  **Users**
    -   `UserID` (PK, Identity)
    -   `EmployeeID` (varchar, unique)
    -   `Nama` (varchar)
    -   `Jabatan` (varchar)
    -   `Bagian` (varchar)
    -   `Unit` (varchar)
    -   `TipeKaryawan` (varchar) -- e.g., 'Monthly', 'Daily'
    -   `KomputerType` (varchar) -- e.g., 'Dedicated', 'Shared'
    -   `PasswordHash` (varchar)
    -   `Role` (varchar) -- 'Admin', 'Staff'

2.  **ActivityLogs**
    -   `LogID` (PK, Identity)
    -   `UserID` (FK to Users.UserID)
    -   `Tanggal` (date)
    -   `ComputerNo` (varchar)
    -   `AktivitasID` (FK to MasterActivities.AktivitasID)
    -   `Deskripsi` (text)
    -   `DigunakanOleh` (varchar)
    -   `FilePath` (varchar) -- path untuk file upload
    -   `WaktuMulai` (time)
    -   `WaktuSelesai` (time)
    -   `DurasiMenit` (int) -- disimpan dalam menit untuk memudahkan perhitungan
    -   `FrekuensiID` (FK to MasterFrequencies.FrequencyID)
    -   `MetodeKerjaID` (FK to MasterWorkMethods.MethodID)
    -   `AplikasiID` (FK to MasterApplications.ApplicationID)
    -   `JenisDok` (varchar)
    -   `NamaDok` (varchar)
    -   `AsalDok` (varchar)
    -   `Keterangan` (text)

3.  **MasterActivities** (Contoh tabel master)
    -   `AktivitasID` (PK, Identity)
    -   `NamaAktivitas` (varchar) -- e.g., 'Pemasukan Data'

4.  **MasterFrequencies**
    -   `FrequencyID` (PK, Identity)
    -   `NamaFrekuensi` (varchar) -- e.g., 'Harian'

5.  **MasterWorkMethods**
    -   `MethodID` (PK, Identity)
    -   `NamaMetode` (varchar) -- e.g., 'Sistem Aplikasi'

6.  **MasterApplications**
    -   `ApplicationID` (PK, Identity)
    -   `NamaAplikasi` (varchar) -- e.g., 'DTS'

*(Tabel master lainnya bisa dibuat dengan pola yang serupa)*

### 7. Alur Kerja (Workflow)

1.  **Setup (Admin):** Admin login ke aplikasi, mengisi data master (Modul 4) dan mendaftarkan pengguna staf baru (Modul 1).
2.  **Input Data (Staf):** Staf login setiap hari. Mereka membuka halaman Input Data (Modul 2), mengisi form aktivitas mereka sepanjang hari, dan menyimpannya.
3.  **Analisis (Admin/Manajer):** Admin atau manajer membuka halaman Dashboard (Modul 3). Mereka memilih filter (misal: bulan "Mei 2024" untuk "Bagian Produksi"). Sistem akan menampilkan grafik dan angka KPI sesuai filter yang dipilih.

---