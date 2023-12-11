import Header from '../components/Header';
import Footer from '../components/Footer';
import { Outlet } from 'react-router-dom';

function Container() {
  return (
    <div className="sm:scroll-smooth">
      <Header />
      <Outlet />
      <Footer />
    </div>
  )
}

export default Container;