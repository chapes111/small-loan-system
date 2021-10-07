import React, { Component } from 'react'
import axios from 'axios';

const baseURL = 'https://localhost:1052/api/LoanRequest';

export default class LoanRequests extends Component {
  constructor(props) {
    super(props);
    this.state = {
      statusText: "Loading....",
      loading: true,
      loanRequests: []
    };
  }

  componentDidMount() {
    axios
    .get(baseURL)
    .then((response) => {
      const loanRequests = response.data;
      this.setState({ loanRequests: loanRequests, loading: false })
    })
    .catch((e)=> {
      this.setState({ statusText: `Error loading data: ${e}`});
    });
  }

  render() {
    return (
      <div className='addrs'>
        <h1>Loan Requests</h1>

        <button
          onClick={() => {window.location = '/Loan/new'}}>
            Create New
            </button>

        {/* TODO: better presentation of loan details */}

        {this.state.loading ?
        <p>{this.state.statusText}</p> :
        this.state.loanRequests.map((_,i) => {
          return <article className='addr-item' key={i}>
            {_.loanRequestId} {_.date} {_.borrowerId} {_.amount} {_.description} {_.payday} {_.borrower}
            </article>
        })}

      </div>
    )
  }
}
