public class Merged {

    public static void main(String args[]) {
        int[] xs = { 3, 5, 12 };
        int[] ys = { 2, 3, 4, 7 };
        int[] merged = merge(xs, ys);
        for (int i = 0; i < merged.length; i++) {
            System.out.println(merged[i]);
        }
    }
    static int[] merge(int[] xs, int[] ys) {
        int[] merged = new int[xs.length + ys.length];
    
        int x, y, z;
        x = y = z = 0;
    
        while(x < xs.length && y < ys.length) {
            if (xs[x] < ys[y]) merged[z++] = xs[x++];
            else merged[z++] = ys[y++];
        }
    
        while (x < xs.length) merged[z++] = xs[x++];
        while (y < ys.length) merged[z++] = ys[y++];
    
        return merged;
    }
}
