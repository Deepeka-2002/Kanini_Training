import React ,{useState,useEffect} from 'react';
import axios from'axios';
import 'bootstrap/dist/css/bootstrap.css';

const StudentCRUD = () =>{
    const [students,setStudents] = useState([]);
    const basepath = "https://localhost:7155";

    const newStudent = {
        "studId" : 5,
         "name" : "Maha",
         "city":"Delhi",
         "pin": 177323
    };

    const updatedStudent ={
        "name": "Gokul",
        "city":"Mumbai",
         "pin":456778
    };

    useEffect(()=>{
        fetchStudentss();
    },[students]);

    const fetchStudentss = async() =>{
        try{
            const response = await axios.get(basepath +`/Student`);
            setStudents (response.data);
            
        }
        catch(error){
            console.error(error);
        }
    }

    const createStudent = async() =>{
        try{
            const response = await axios.post(basepath +`/Student`,newStudent);
            setStudents([...students,response.data]);
        }
        catch(error){
            console.error(error);
        }
    }

    const updateStudent = async(id) => {
        try{
            console.log(id);
            const response= await axios.put (basepath + `/Student/${id}`,updatedStudent);
            const updates = students.map((student)=>{
                if(student.studId === id){
                    return response.data;
                }
                return student;
            });
            setStudents(updates);
        }
        catch(error){
            console.error(error);
        }
    }

    const deleteStudent = async(id) => {
        console.log(id);
        await axios.delete(basepath + `/Student/${id}`);
        fetchStudentss();
    //     const updates = students.filter((student) => student.studid != id);
    //    setStudents(updates);
    }

    return(
        <div>
            <h1>Student CRUD</h1>
            <button class="btn btn-success" onClick={createStudent}>Create Student</button>
            <table class="table">
               <thead>
                <tr>
                 <th scope="col">Id:</th>
                 <th scope="col">Name:</th>
                 <th scope="col">City:</th>
                 <th scope="col">Pin:</th>
                 <th scope="col">Edit:</th>
                 <th scope="col">Del:</th>
                 </tr>
               </thead>
               <tbody>
                {students.map((student)=>(
                    <tr key={student.studId}>
                    
                        <td>{student.studId}</td>
                        <td>{student.name}</td>
                        <td>{student.city}</td>
                        <td>{student.pin}</td>
                        <td><button class ="btn btn-warning"onClick={()=> updateStudent(student.studId)}>Update</button></td>
                        <td><button class ="btn btn-danger"onClick={()=> deleteStudent(student.studId)}>Delete</button></td>
                    </tr>
                   
                ))}
                </tbody>
            </table>

        </div>
    )

}
export default StudentCRUD;