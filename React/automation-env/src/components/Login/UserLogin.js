import { useState } from "react";
import {requestGet} from "../../backend/apiClient/apiClient.jsx";

// const database = [
//     {
//       username: "user1",
//       password: "pass1"
//     },
//     {
//       username: "user2",
//       password: "pass2"
//     }
//   ];
  
//   const errors = {
//     uname: "invalid username",
//     pass: "invalid password"
//   };

// const handleSubmit = (event) => {
//   event.preventDefault();

//   const form = event.target;
//   var {userName, password} = form;

//   const userData = database.find((user)=> user.username == userName.value );

//   if(userData){
//      if(userData.password !== password.value)
//         alert("Error");
//     else   
//         alert("Signed");
//   }
//   else
//     alert("User Invalid");

// }

const asyncHandleSubmit = async(event) =>{
  event.preventDefault();

  const form = event.target;
  var {username, password} = form;
   
  const response = await requestGet("/Customer",{user:username, password:password});
  alert(response.data);  
}

export default function UserLogin(){
 const [uname,setUserName] = useState('');
 const [pass,setPassword] = useState('');
 return(
<div>
  <form method="post" onSubmit={asyncHandleSubmit}>
    <div>
        <input type="text" name="userName" required value={uname} onChange={e=> setUserName(e.target.value)}></input>
    </div>
    <div>
        <input type="password" name="password" required value={pass} onChange={e=> setPassword(e.target.value)}></input>
    </div>
    <div>
        <input type="submit"/>
    </div>
  </form>
</div>
 );
}