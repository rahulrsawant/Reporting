//this is main navigation layout for the app, it includes a nav bar and an outlet for the child routes
import { Link, Outlet, useNavigate } from 'react-router'

function Layout() {
  const navigate = useNavigate()

  async function handleLogout() {
    await fetch('/api/auth/logout', { method: 'POST' })
    navigate('/login')
  }

  return (
    <div>
      <nav>
        <Link to="/">Home</Link> | <Link to="/funds">Funds</Link> |{' '}
        <Link to="/investors">Investors</Link>
        <button onClick={handleLogout}>Log out</button>
      </nav>

      <main>
        <Outlet />
      </main>
    </div>
  )
}

export default Layout