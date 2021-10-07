import { ToastContainer, toast } from 'react-toastify';
import DatePicker from 'react-datepicker';
import toastCss from 'react-toastify/dist/ReactToastify.css';

import dateCss from "react-datepicker/dist/react-datepicker.css";

const notify = (message, err) => err ? toast.error(message, {
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

const toastProps = {
  position: "top-right",
  autoClose: 5000,
  hideProgressBar: false,
  newestOnTop: false,
  closeOnClick: true,
  rtl: false,
  pauseOnFocusLoss: true,
  draggable: true,
  pauseOnHover: true,
}

export { notify, toastProps, ToastContainer, toastCss, dateCss }
