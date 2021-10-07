import React, { Component } from 'react';
import axios from 'axios';
import DatePicker from 'react-datepicker';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import "react-datepicker/dist/react-datepicker.css";

// TODO: move this to config file
const baseURL = 'https://localhost:1052/api/LoanRequest';
const getAddressees = 'https://localhost:1052/api/Addressee';

export default class NewLoanRequest extends Component {
  constructor(props) {
    super(props);
    this.state = {
      date: new Date(),
      borrowerId: null,
      deadline: new Date(),
      amount: 0,
      description: '',
      payday: new Date(),
      addressees: [],
      loading: false,
      statusText: '',
      startDate: new Date()
    }
  }

  notify = (message, err) => err ? toast.error(message, {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
  })
  : toast.success(message, {
      position: "top-right",
      autoClose: 5000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
  });

  setDate = date => {
    this.setState({ date: date });
  }

  setDeadline = date => {
    this.setState({ deadline: date });
  }

  setPayday = date => {
    this.setState({ payday: date });
  }

  componentDidMount() {
    axios
    .get(getAddressees)
    .then((response) => {
      console.dir(response);
      const addressees = response.data;
      this.setState({ addressees: addressees, loading: false })
    })
    .catch((e)=> {
      this.setState({ statusText: `Error loading data: ${e}`});
    });
  }

  handleSubmit = (event) => {
    event.preventDefault();
    // TODO: borrowerId and amount not saving correctly in DB
    let loanRequest = {
      date: this.state.date,
      borrowerId: this.state.borrowerId,
      deadline: this.state.deadline,
      amount: this.state.amount,
      description: this.state.description,
      payday: this.state.payday
    };
    axios
    .post(baseURL, loanRequest)
    .then(res => {
      this.setState({
        date: new Date(),
        borrowerId: null,
        deadline: new Date(),
        amount: 0,
        description: '',
        payday: new Date(),
        loading: false,
        statusText: '',
        startDate: new Date()
      }, () => this.notify("Form submitted!", false));
      document.getElementById('loanForm').reset();
    })
    .catch(err => {
      this.notify(`Failure: ${err}`, true);
    });
  }

  handleChange = (evt) => {
    const val = evt.target.value;
    this.setState({
      ...this.state,
      [evt.target.name]: val
    });
  }

  render() {
    return (
      <div>
        <ToastContainer
          position="top-right"
          autoClose={5000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
          />
          {/* Same as */}
          <ToastContainer />

        <form onSubmit={this.handleSubmit} id='loanForm'>
          <h1>New Loan Form</h1>

          <section>
            <label htmlFor='date'>Date</label>
            <DatePicker selected={this.state.date} onChange={this.setDate} dateFormat='MM/dd/yyy' />
          </section>

          <section>
            <label htmlFor='borrowerId'>Borrower Id</label>
            <select onChange={this.handleChange} id='borrowerId' name='borrowerId' required>
              {this.state.loading ?
              <option value=''>Loading....</option>
              : this.state.addressees.map((_,i) => {
                return (
                  <option key={i} value={_.id}>{_.name}</option>
                )
              })}
            </select>
          </section>

          <section>
            <label htmlFor='deadline'>Deadline</label>
            <DatePicker selected={this.state.deadline} onChange={this.setDeadline} dateFormat='MM/dd/yyyy' />
          </section>

          <section>
            <label htmlFor='amount'>Amount</label>
            <input onChange={this.handleChange} id='amount' name='amount' type="number" min="1" step="any" />
          </section>

          <section>
            <label htmlFor='description'>Description</label>
            <textarea onChange={this.handleChange} id='description' name='description' autoComplete='description' maxLength='300' required></textarea>
          </section>

          <section>
            <label htmlFor='payday'>Pay Day</label>
            <DatePicker selected={this.state.payday} onChange={this.setPayday} dateFormat='MM/dd/yyyy' />
          </section>

          <button type='submit'>Submit</button>
        </form>

      </div>
    )
  }
}
