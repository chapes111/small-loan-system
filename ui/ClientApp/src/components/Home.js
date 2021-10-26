import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import vidImg from '../../src/images/watch.svg';
import illustration from '../../src/images/illustration.svg';
import phoneImg from '../../src/images/holding-phone.jpg';
import personImg from '../../src/images/person.jpg';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <section className='hero'>
          <div className='container'>
            <div className='left-col'>
              <p className='subhead'>Maximize Your Investments!</p>
              <h1>Rupert Investments</h1>

              <div className='hero-cta'>
                <Link to='/LoanRequests' className='primary-cta'>Request A Loan</Link>
                <Link to='#' className='watch-video-cta'>
                  <img src={vidImg} alt='Watch a video' />Watch a demonstration
                </Link>
              </div>

              <img src={illustration} className='hero-img' alt='Illustration' />

            </div>
          </div>
        </section>


        <section class="features-section">
          <div class="container">
              <ul class="features-list">
                  <li>Unlimited Tasks</li>
                  <li>SMS Task Reminders</li>
                  <li>Confetti Explosions upon Task Completions</li>
                  <li>Social Media Announcements</li>
                  <li>Real Time Collaboration</li>
                  <li>Other awesome features</li>
              </ul>

            <img src={phoneImg} alt="Man holding phone" />
          </div>
        </section>

        <section class="testimonials-section">
          <div class="container">
              <ul>
                  <li>
                      <img src={personImg} alt="person" />
                      <blockquote>Nisi voluptatem dolores ea adipisci et aut eos quo. Aut at est sit aut. Optio quia molestiae ut ut facere placeat.</blockquote>
                      <cite>- Jane Doe</cite>
                  </li>
                  <li>
                      <img src={personImg} alt="person" />
                      <blockquote>Nisi voluptatem dolores ea adipisci et aut eos quo. Aut at est sit aut. Optio quia molestiae ut ut facere placeat.</blockquote>
                      <cite>- Jane Doe</cite>
                  </li>
                  <li>
                      <img src={personImg} alt="person" />
                      <blockquote>Nisi voluptatem dolores ea adipisci et aut eos quo. Aut at est sit aut. Optio quia molestiae ut ut facere placeat.</blockquote>
                      <cite>- Jane Doe</cite>
                  </li>
              </ul>
          </div>
        </section>

        <section class="contact-section">
          <div class="container">
              <div class="contact-left">
                  <h2>Contact</h2>

                  <form action="">
                      <label for="name">Name</label>
                      <input type="text" id='name' name='name' />

                      <label for="message">Message</label>
                      <textarea name='message' id='message' cols='30' rows="10"></textarea>

                      <input type="submit" class="send-message-cta" value="Send Message" />
                  </form>
              </div>
              <div class="contact-right">
                  <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d12721.864543968763!2d-80.41269727994272!3d37.1416143271143!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x884d93ac2bbae191%3A0xcec10c5df9810d32!2sBeverly%20Hills%2C%20Christiansburg%2C%20VA%2024073!5e0!3m2!1sen!2sus!4v1634927574141!5m2!1sen!2sus" width="600" height="450" style={{border: '0'}} allowfullscreen="" loading="lazy"></iframe>
              </div>
          </div>
        </section>

      </div>
    );
  }
}
