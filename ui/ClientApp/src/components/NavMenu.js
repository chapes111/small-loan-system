import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import menuIcon from '../../src/images/menu.svg';
import menuExit from '../../src/images/exit.svg';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
        const mobileBtn = document.getElementById('mobile-cta');
        const nav = document.querySelector('nav');
        const mobileBtnExit = document.getElementById('mobile-exit');

        mobileBtn.addEventListener('click', () => {
            nav.classList.add('menu-btn');
        });

        mobileBtnExit.addEventListener('click', () => {
            nav.classList.remove('menu-btn');
        });
  }

  render () {
    return (
        <div className='navbar' light>
          <div className='container'>
            <a className='logo' href="/">small_loan_system</a>

            <img id='mobile-cta' className='mobile-menu' onClick={this.toggleNavbar} src={menuIcon} alt='Open Navigation' />

            <nav>
              <img id='mobile-exit' class='mobile-menu-exit' src={menuExit} alt="" />
              <ul className="primary-nav">
                  <li className="current"><Link to='/'>Home</Link></li>
                  <li><Link to='/Addressees'>Addressees</Link></li>
              </ul>
              <ul className='secondary-nav'>
                  <li className='go-premium-cta'>
                    <Link to='/LoanRequests'>Loan Requests</Link>
                  </li>
              </ul>
            </nav>
          </div>

          
        </div>
    );
  }
}
