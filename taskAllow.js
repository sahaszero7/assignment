import React, { useState } from "react";
import "./app.css";


const App = () => {
 const [title, setstitle] = useState("");
 const [Description, setDescription] = useState("");
 const [deudate, setdeudate] = useState("");



 const handleSubmit = (e) => {
   e.preventDefault();
   alert("Successfully added a task.");
 };

 return (
   <div className="app">
    <h1>Task Allocation</h1>
     <form onSubmit={handleSubmit} >
       <h1>Task </h1>
       <div className="formInput">
         <label>title</label>
         <input
           type="text"
           name="title"
           value={title}
           placeholder="Enter your title..."
           onChange={(e) => setEmail(e.target.value)}
         />
       </div>
       <div className="formInput">
         <label>Description</label>
         <input
           type="text"
           name="Description"
           value={Description}
           placeholder="Enter your Description..."
           onChange={(e) => setEmail(e.target.value)}
         />
       </div>
       <div className="formInput">
         <label>DeuDate</label>
         <input
           type="date"
           name="deudate"
           value={deudate}
           onChange={(e) => setEmail(e.target.value)}
         />
       </div>
       <div className="formInput">
         <label>Status</label>
         
            <select name="Status" id="status">
                <option value="todo">todo</option>
                <option value="in-progress">in-progress</option>
                <option value="completed">completed</option>
                
            </select>
            </div>
       
       <button>Submit</button>
     </form >
   </div >
 );
};


export default App;