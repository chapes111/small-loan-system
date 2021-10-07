import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Rupert Investments</h1>
        <p>Welcome to the <strong>Rupert Investments Web Portal</strong></p>
        <ul>
          <li><a href='/Invest'>Invest</a></li>
          <li><a href='/Borrowers'>Borrow</a></li>
          <li><a href='/Loan'>Loan Status</a></li>
          <li><a href='/Addressees'>Addresses</a></li>
        </ul>
      </div>
    );
  }
}
