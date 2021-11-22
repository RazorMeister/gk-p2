Autor: Tymoteusz Bartnik. Nr albumu: 305852.

Program: Projekt 2 - Wypełnianie.

Klawiszologia: brak specjalnych funkcji przypisanych do klawiszy. Pełna obsługa programu poprzez kontrolki w oknie.

W celu optymalizacji obliczania odpowiedniego koloru dla poszczególnych pikseli dodano tryb CUDA, który wykorzystuje technologię Nvidia CUDA. Do poprawnego działania potrzebna jest karta graficzna NVIDIA obsługująca tę technologię oraz zainstalowany Nvidia CUDA toolkit: https://developer.nvidia.com/cuda-downloads. Realny wzrost FPS przy testach to około 30% przy maksymalnej dostępnej gęstości trojkątów w triangulacji. Projekt przesyłam w wersji .Net Framework 4.8, ale gdyby wystąpiły problemy z obsługą CUDA to bardziej sprawdzoną wersją jest .Net Framework 4.5.

Oprócz trybu dokładnego liczenia koloru dla każdego piksela oraz interpolacji dodałem tryb One pixel, który koloruje cały trójkąt na podstawie koloru wyliczonego dla punktu ciężkości trójkąta.

Algorytm wypełniania nie jest wykorzystywany w każdej klatce tylko w momencie zmiany parametrów np. dokładności triangulacji. Każdy obiekt trójkąta ma przypisywane wtedy piksele (za pomocą algorytmu wypełniania), które do niego należą i wyliczane wektory normalne. Dzięki takiemu zabiegowi płynność animacji drastycznie wzrosła.

Domyślnie jest wgrana jedna tekstura, przy kliknięciu w przycisk `Load Texture` zostanie otworzony główny katalog aplikacji. W nim znajduje się katalog SampleTextures z innymi przykładowymi teksturami. Wgrywanie i wyliczanie mapy normalnej z tekstury jest realizowane asynchronicznie i może potrwać około 5-6 sekund w zależności od procesora ponieważ samo wyliczanie nie jest zrównoleglone ze względu na tworzenie podglądu tekstury i wygenerowanej do niej mapy wektorów.