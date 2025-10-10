// micro-C Our first example
// takes small and larger number and makes array
// with integers between and including params
// buffer 100

// run (fromFile "Exercise_7.2.1.c") [3; 5];;
// 3 4 5

void main(int n, int m) {

  int Arr[100];
  
  int i;
  
  i = n;
  while (i <= m) {
    Arr[i-n] = i;
    print Arr[i-n];
    i = i + 1;
  }
}
