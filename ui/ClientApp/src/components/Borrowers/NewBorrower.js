import React, { Component } from 'react'
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import axios from 'axios';

const addressees = 'https://localhost:1052/api/Addressee';

export default class NewBorrower extends Component {
  constructor(props) {
    super(props);
    this.state = {
      statusText: "Loading....",
      loading: true,
      addressees: []
    };
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

  componentDidMount() {
    axios
    .get(addressees)
    .then((response) => {
      console.dir(response);
      const addressees = response.data;
      this.setState({ addressees: addressees, loading: false })
    })
    .catch((e)=> {
      this.setState({ statusText: `Error loading data: ${e}`});
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
          <h1>New Borrower Form</h1>

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

          <button type='submit'>Submit</button>
        </form>

      </div>
    )
  }
}
