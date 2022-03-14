import React, { Component} from "react";
import axios from 'axios';



class Home extends Component {
  constructor(props) {
    super(props);
    

    this.state = {customerlist: [{
      id: 1,
      name: "",
      streetAddress: "",
      city: "",
      state: "",
      zip: "",
    },
    
  ]}
 
}

// Haetaan backendiltä kovakoodattu lista asiakkaista
  componentDidMount() {
    let self = this
    axios.get('http://localhost:5245/Customer', {})
    .then(function (response) {
      console.log(self)
      self.setState({customerlist: response.data})
  }).catch(error => console.log(error))
    self.forceUpdate()
  }
  
   render() {
    return (
      <div>
        <h2>Kaikki asiakkaat</h2>
        <p></p>
        <div>
      {this.state.customerlist.map((person, index) => (
        <p key={index}>{person.name} {person.streetAddress} {person.city} {person.state} {person.zip}</p>
      ))}
    </div>
    </div>
    );
  }
}
 
export default Home;
