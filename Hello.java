public class Hello {
    private static Hello instance;

    public static Hello newInstance() {
        return new Hello();
    }

    public static void main(String[] a)
    {
        System.out.print("Hello World! : ");
        for(int i=0;i<a.length;i++) {
            System.out.print(a[i]);
        }
        System.out.println();
    }

    public static void mainT()
    {
        System.out.println("mainT Hello World!");
    }

    public static int Sum(int x, int y)
    {
        return x + y;   
    }

    public void nonStaticMain()
    {
        System.out.println("nonStaticMain Hello World!");
    }
}