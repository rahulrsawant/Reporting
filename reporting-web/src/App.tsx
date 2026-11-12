import { BrowserRouter, Routes, Route } from 'react-router'
import LoginPage from './pages/LoginPage'
import HomePage from './pages/HomePage'
import FundsPage from './pages/FundsPage'
import InvestorsPage from './pages/InvestorsPage'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/" element={<HomePage />} />
        <Route path="/funds" element={<FundsPage />} />
        <Route path="/investors" element={<InvestorsPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App