import React ,{useState,useEffect} from 'react';
import axios from'axios';
import 'bootstrap/dist/css/bootstrap.css';

const StudentCrudFetch = () =>{
    const [students,setStudents] = useState([]);
    const basepath = "https://localhost:7155";

    // const newStudent = {
    //     "studId" : 5,
    //      "name" : "Maha",
    //      "city":"Delhi",
    //      "pin": 177323
    // };

    // const updatedStudent ={
    //     "name": "Gokul",
    //     "city":"Mumbai",
    //      "pin":456778
    // };

    useEffect(()=>{
        fetchStudentss();
    },[students]);

    const fetchStudentss = async() =>{
     fetch(basepath + `/Student`)
     .then((response) => response.json())
     .then((data) => setStudents(data))
     .catch((error) => console.error(error))
    }

    const createStudent = () => {
        fetch('https://localhost:7155/Student', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(newStudent),
        })
          .then((response) => response.json())
          .then((data) => {
            setStudents([...students, data]);
            setNewStudent({studId:'', name: '', city: '', pin: '' });
          })
          .catch((error) => console.error(error));
      };

      const updateStudent = (id, updatedStudent) => {
        fetch(`https://localhost:7155/Student/${id}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(updatedStudent),
        })
          .then((response) => response.json())
          .then((data) => {
            const updatedStudents = students.map((student) => {
              if (student.studId === id) {
                return data;
              }
              return student;
            });
            setStudents(updatedStudents);
          })
          .catch((error) => console.error(error));
      };
    
      const deleteStudent = (id) => {
        fetch(`https://localhost:7061/Student/${id}`, {
          method: 'DELETE',
        })
          .then(() => {
            const updatedStudents = students.filter((student) => student.studId !== id);
            setStudents(updatedStudents);
          })
          .catch((error) => console.error(error));
      };
    // const createStudent = async() =>{
    //     try{
    //         const response = await axios.post(basepath +`/Student`,newStudent);
    //         setStudents([...students,response.data]);
    //     }
    //     catch(error){
    //         console.error(error);
    //     }
    // }

    // const updateStudent = async(id) => {
    //     try{
    //         console.log(id);
    //         const response= await axios.put (basepath + `/Student/${id}`,updatedStudent);
    //         const updates = students.map((student)=>{
    //             if(student.studId === id){
    //                 return response.data;
    //             }
    //             return student;
    //         });
    //         setStudents(updates);
    //     }
    //     catch(error){
    //         console.error(error);
    //     }
    // }

    // const deleteStudent = async(id) => {
    //     console.log(id);
    //     await axios.delete(basepath + `/Student/${id}`);
    //     fetchStudentss();
    //     const updates = students.filter((student) => student.studid != id);
    //    setStudents(updates);
    }

    return(
        <div>
   
      <h1>Student CRUD Operations</h1>
      <h2>Create Student</h2>
      <input
        type="number"
        placeholder="Id"
        value={newStudent.studId}
        onChange={(e) => setNewStudent({ ...newStudent, studId: e.target.value })}
      />
      <input
        type="text"
        placeholder="Name"
        value={newStudent.name}
        onChange={(e) => setNewStudent({ ...newStudent, name: e.target.value })}
      />
      <input
        type="text"
        placeholder="City"
        value={newStudent.city}
        onChange={(e) => setNewStudent({ ...newStudent, city: e.target.value })}
      />
      <input
        type="number"
        placeholder="Pin"
        value={newStudent.pin}
        onChange={(e) => setNewStudent({ ...newStudent, pin: e.target.value })}
      />
      <button onClick={createStudent}>Create Student</button>

      <h2>Update Students</h2>
      <ul>
        {students.map((student) => (
          <li key={student.studId}>
            <span>{student.name}</span>
            <span>{student.city}</span>
            <span>{student.pin}</span>
            <button onClick={() => updateStudent(student.studId, { name: 'Updated Name' })}>Update</button>
            <button onClick={() => deleteStudent(student.studId)}>Delete</button>
          </li>
        ))}
      </ul>
 
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


export default StudentCrudFetch;