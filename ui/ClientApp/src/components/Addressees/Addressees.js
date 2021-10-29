import React, { Component } from 'react'
import axios from 'axios';

const baseURL = 'https://localhost:1052/api/Addressee';

export default class Addressees extends Component {
  constructor(props) {
    super(props);
    this.state = {
      statusText: "Loading....",
      loading: true,
      addressees: []
    };
  }

  componentDidMount() {
    axios
    .get(baseURL)
    .then((response) => {
      const addresses = response.data;
      this.setState({ addressees: addresses, loading: false })
    })
    .catch((e)=> {
      this.setState({ statusText: `Error loading data: ${e}`});
    });
  }

  render() {
    return (
      <div className='addr-container'>
        <ul className='addr-list'>
          <button
            onClick={() => {window.location = '/Addressees/new'}}>
              Create New
              </button>
          {this.state.loading ?
          <p className='status-text'>{this.state.statusText}</p> :
          this.state.addressees.map((_,i) => {
            return <li className='addr-item' key={i}><span className='name'>{_.name}</span> <span className='address'>{_.address}</span></li>
          })}
        </ul>


      </div>
    )
  }
}
