//Exercise_7.2

void arrsum(int n, int arr[], int *sump) {
    int i;
    i = 0;

    while (i < n) {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}

//For loop version

void arrsum2(int n, int arr[], int *sump) {
    int i;
    for (i = 0; i < n; i = i + 1) {
        *sump = *sump + arr[i];
    }
}

void squares(int n, int arr[]) {
    int i;
    i = 0;

    while (i < n) {
        arr[i] = i * i;
        i = i + 1;
    }
}

//For loop version

void squares2(int n, int arr[]) {
    int i;

    for (i = 0; i < n; i = i + 1) {
        arr[i] = i * i;
    }
}

void histogram(int n, int ns[], int max, int freq[]) {
    int i;
    i = 0;
    while (i < max+1) {
        freq[i] = 0;
        i = i + 1;
    }
    i = 0;
    while (i < n) {
        freq[ns[i]] = freq[ns[i]] + 1;
        i = i + 1;
    }
}

//For loop version

void histogram2(int n, int ns[], int max, int freq[]) {
    int i;

    for (i = 0; i < max + 1; i = i + 1) {
        freq[i] = 0;
    }

    for (i = 0; i < n; i = i + 1) {
        freq[ns[i]] = freq[ns[i]] + 1;
    }
}

void main() {
    // i
    int arr1[4];
    arr1[0] = 7;
    arr1[1] = 13;
    arr1[2] = 9;
    arr1[3] = 8;
    
    int *sump;
    *sump = 0;
    arrsum(4, arr1, sump);
    print *sump;

    // ii
    int arr2[20];
    squares(20, arr2);
    *sump = 0;
    arrsum(20, arr2, sump);
    print *sump;

    // iii
    int ns[7];
    ns[0] = 1; 
    ns[1] = 2; 
    ns[2] = 1; 
    ns[3] = 1; 
    ns[4] = 1; 
    ns[5] = 2; 
    ns[6] = 0;
    int freq[4];
    histogram(7, ns, 3, freq);
    int i;
    i = 0;
    while (i <= 3) {
        print freq[i];
        i = i + 1;
    }

    //For loop version

    // i
    arr1[0] = 7;
    arr1[1] = 13;
    arr1[2] = 9;
    arr1[3] = 8;
    
    *sump = 0;
    arrsum2(4, arr1, sump);
    print *sump;

    // ii
    squares2(20, arr2);
    *sump = 0;
    arrsum2(20, arr2, sump);
    print *sump;

    // iii
    histogram2(7, ns, 3, freq);
    for (i = 0; i <= 3; i = i + 1) {
        print freq[i];
    }
}
