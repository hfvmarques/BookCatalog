import React, { useState, useEffect } from 'react'
import { Link, useHistory } from 'react-router-dom'
import { FiEdit, FiTrash2 } from 'react-icons/fi'
import './styles.css'
import logoImage from '../../assets/logo.svg'
import api from '../../services/api'

export default function BookCatalog() {

  const [bookRepository, setBookRepository] = useState([])
  const [searchSubject, setSearchSubject] = useState('')
  const handleChange = event => {
    setSearchSubject(event.target.value)
  }

  const history = useHistory()

  useEffect(() => {
    api.get('/books').then(response => {
      setBookRepository(response.data)
    })
  }, [])

  async function editBook(id) {
    try {
      history.push(`Book/${id}`)

    } catch (err) {
      alert('Não foi possível editar o livro. Tente novamente.')
    }
  }

  async function deleteBook(id) {
    try {
      await api.delete(`/books/${id}`)
      setBookRepository(bookRepository.filter(book => book.id !== id))

    } catch (err) {
      alert('Não foi possível apagar o livro. Tente novamente.')
    }
  }

  return (
    <div className="bookCatalog-container">
      <header>
        <img src={logoImage} alt="Catálogo de livros" />
        <span>Catálogo de Livros</span>
        <input
          className="searchField"
          type="text"
          placeholder="Busca por assunto"
          value={searchSubject}
          onChange={handleChange} />
        <Link className="button" to="/Book/0">Adicionar novo livro</Link>
      </header>

      <h1>Livros Registrados</h1>
      <table>
        <thead>
          <th>Título</th>
          <th>Autor</th>
          <th>Editora</th>
          <th>Ano de Publicação</th>
          <th>Edição</th>
          <th>Assunto</th>
          <th>Editar</th>
          <th>Deletar</th>
        </thead>
        {bookRepository.filter(book => {
          if (searchSubject === "") {
            return book
          }

          return book.subject.toLowerCase().includes(searchSubject.toLowerCase())

        }).sort((a, b) => a.title > b.title ? 1 : -1).map(book => (
          <tbody key={book.id}>
            <td className="titulo">{book.title}</td>
            <td className="autor">{book.author}</td>
            <td className="editora">{book.publishingCompany}</td>
            <td className="anoPublicacao">{book.publicationYear}</td>
            <td className="edicao">{book.edition}ª</td>
            <td className="assunto">{book.subject}</td>
            <td>
              <button onClick={() => editBook(book.id)} type="button">
                <FiEdit size={20} color="#251FC5" />
              </button>
            </td>
            <td>
              <button onClick={() => { if (window.confirm('Tem certeza que deseja apagar este livro?')) deleteBook(book.id) }} type="button">
                <FiTrash2 size={20} color="#251FC5" />
              </button>
            </td>
          </tbody>
        ))}
      </table>
    </div>
  )
}