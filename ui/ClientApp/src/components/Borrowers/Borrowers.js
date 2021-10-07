import React, { Component } from 'react'
import axios from 'axios';

const baseURL = 'https://localhost:1052/api/Borrower';

export default class Borrowers extends Component {
  constructor(props) {
    super(props);
    this.state = {
      statusText: "Loading....",
      loading: true,
      borrowers: []
    };
  }

  componentDidMount() {
    axios
    .get(baseURL)
    .then((response) => {
      const borrowers = response.data;
      this.setState({ borrowers: borrowers, loading: false })
    })
    .catch((e)=> {
      this.setState({ statusText: `Error loading data: ${e}`});
    });
  }

  render() {
    return (
      <div>
        <h1>Borrowers</h1>

        <button
          onClick={() => {window.location = '/Borrowers/new'}}>
            Create New
            </button>

        {this.state.loading ?
        <p>{this.state.statusText}</p> :
        this.state.borrowers.map((_,i) => {
          return <article className='addr-item' key={i}>
            {_.id} {_.addresseeId}
            {_.lenderBorrowers.map((_,i) => { return _ })}
            {_.loanRequests.map((_,i) => { return _ })}
            </article>
        })}

      </div>
    )
  }
}
