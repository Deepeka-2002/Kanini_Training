import React ,{useState,useEffect} from 'react';
import axios from'axios';
import 'bootstrap/dist/css/bootstrap.css';

const CrudwithUI = () =>{
    const [students,setStudents] = useState([]);
    const basepath = "https://localhost:7155";

    const [newStudent, setNewStudent] = useState({
        studId : "",
        name : "",
        city:"",
        pin: ""
});

const [editStudent, setEditStudent] = useState({
 
    name : "",
    city:"",
    pin: ""
});


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
            setNewStudent({studId: "",name:"",city:"",pin:""});
        }
        catch(error){
            console.error(error);
        }
    }

    const updateStudent = async(id) => {
        try{
            console.log(id);
            const response= await axios.put (basepath + `/Student/${id}`,editStudent);
            setStudents([...students,response.data]);
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
            <h3>Create Student</h3>
            <form>
        <div class="form-group">
      <input
        type="text"
        placeholder="Id"
        value={newStudent.studId}
        onChange={(e) =>
          setNewStudent({ ...newStudent, studId: e.target.value })}
      />
      </div><br></br>

      <div class="form-group">
      <input
        type="text"
        placeholder="Name"
        value={newStudent.name}
        onChange={(e) => setNewStudent({ ...newStudent, name: e.target.value })}
      />
      </div><br></br>

      <div class="form-group">
     
      <input
        type="text"
        placeholder="City"
        value={newStudent.city}
        onChange={(e) => setNewStudent({ ...newStudent, city: e.target.value })}
      />
      </div><br></br>

      <div class="form-group">
      <input
        type="text"
        placeholder="Pin"
        value={newStudent.pin}
        onChange={(e) => setNewStudent({ ...newStudent, pin: e.target.value })}
      />
     </div><br></br>
     <br></br>

      <button class="btn btn-success" onClick={createStudent}>Create Student</button>
      <br></br>
      <br></br>

    </form>

      <h3>All Students</h3>
            <table class="table">
               <thead>
                <tr>
                 <th scope="col">Id</th>
                 <th scope="col">Name</th>
                 <th scope="col">City</th>
                 <th scope="col">Pin</th>
                 <th scope="col">Edit</th>
                 <th scope="col">Del</th>
                 </tr>
               </thead>
               <tbody>
                {students.map((student)=>(
                    <tr key={student.studId}>
                    
                        <td>{student.studId}</td>
                        <td>{student.name}</td>
                        <td>{student.city}</td>
                        <td>{student.pin}</td>

            {editStudent && editStudent.studId === student.studId ? (
              <React.Fragment>
                <input
                  type="text"
                  value={editStudent.studId}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, studId: e.target.value })
                  }
                /> <br></br>
                <input
                  type="text"
                  placeholder="Name"
                  value={editStudent.name}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, name: e.target.value })
                  }
                /><br></br>
                <input
                  type="text"
                  placeholder="City"
                  value={editStudent.city}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, city: e.target.value })
                  }
                /><br></br>
                <input
                  type="text"
                  placeholder="Pin"
                  value={editStudent.pin}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, pin: e.target.value })
                  }
                /><br></br>
                <br></br>
                <button class="btn btn-info"onClick={() => updateStudent(student.studId)}>
                  Save
                </button>{" "}
                &nbsp; &nbsp; &nbsp;
                <button class="btn btn-primary" onClick={() => setEditStudent(null)}>
                  Cancel
                </button>{" "}
                &nbsp; &nbsp; &nbsp;
              </React.Fragment>
            ) : (
                <td>
              <button class="btn btn-warning"onClick={() => { 
                setEditStudent(student);
                console.log(editStudent.studId);
                 }}>
               Update
              </button>
              </td>

            )}

            <td>
            <button class="btn btn-danger" onClick={() => deleteStudent(student.studId)}>
              Delete
            </button>
            </td>
                        {/* <td><button class ="btn btn-warning"onClick={()=> updateStudent(student.studId)}>Update</button></td>
                        <td><button class ="btn btn-danger"onClick={()=> deleteStudent(student.studId)}>Delete</button></td> */}
            </tr>
                   
                ))}
                </tbody>
            </table>

            {/* {editStudent === student.studId ? (
              <React.Fragment>
                <input
                  type="text"
                  value={editStudent.studId}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, studId: e.target.value })
                  }
                />
                <input
                  type="text"
                  placeholder="Name"
                  value={editStudent.name}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, name: e.target.value })
                  }
                />
                <input
                  type="text"
                  placeholder="City"
                  value={editStudent.city}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, city: e.target.value })
                  }
                />
                <input
                  type="text"
                  placeholder="Pin"
                  value={editStudent.pin}
                  onChange={(e) =>
                    setEditStudent({ ...editStudent, pin: e.target.value })
                  }
                />
                <button onClick={() => updateStudent(student.studId)}>
                  Save
                </button>{" "}
                &nbsp; &nbsp; &nbsp;
                <button onClick={() => setEditStudent(null)}>
                  Cancel
                </button>{" "}
                &nbsp; &nbsp; &nbsp;
              </React.Fragment>
            ) : (
              <button onClick={() => { 
                setEditStudent(student.studId)
                console.log(editStudent.studId);
                 }}>
                Edit
              </button>
            )}
            <button onClick={() => deleteStudent(student.studId)}>
              Delete
            </button> */}

        </div>
    )

}
export default CrudwithUI;