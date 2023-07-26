using EFCodeFirst;

class Program
{
    public static void Main(String[] args)
    {
        CrudOperations crud = new CrudOperations();
        //crud.InsertRecordsInStudEntity();
        //crud.InsertRecordsInCourseEntity();
        //crud.UpdateRecordsInStudEntity();
        //crud.DeleteRecordsInStudEntity();
        // crud.ReadRecordsInStudEntity("Ram");
        crud.Projection();
    }
    
}
