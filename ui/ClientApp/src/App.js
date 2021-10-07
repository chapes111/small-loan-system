import React, { Component } from 'react';
import { BrowserRouter, Route, Switch, withRouter } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import './custom.css'
import Loan from './components/LoanRequests/LoanRequests';
import Addressees from './components/Addressees/Addressees';
import AddrNew from './components/Addressees/AddrNew';
import NewLoanRequest from './components/LoanRequests/NewLoanRequest';
import Borrowers from './components/Borrowers/Borrowers'
import NewBorrowers from './components/Borrowers/NewBorrower';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/Loan' component={Loan} />
            <Route path='/Loan/new' component={NewLoanRequest} />
            <Route exact path='/Addressees' component={Addressees} />
            <Route path='/Addressees/new' component={withRouter(AddrNew)} />
            <Route exact path='/Borrowers' component={Borrowers} />
            <Route path='/Borrowers/new' component={withRouter(NewBorrowers)} />
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}
