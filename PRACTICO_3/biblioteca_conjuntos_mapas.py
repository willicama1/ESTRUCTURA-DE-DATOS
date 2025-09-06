import time
import uuid
import random
from dataclasses import dataclass, asdict
from typing import Dict, Set, List, Optional

@dataclass
class Book:
    id: str
    title: str
    author: str
    year: int
    categories: Set[str]

    def to_dict(self):
        d = asdict(self)
        d['categories'] = list(self.categories)
        return d

class Library:
    """Implementa un registro de libros usando un mapa (dict) y conjuntos.

    - self.books: mapa id -> Book
    - self.categories: conjunto con nombres únicos de categorías
    """
    def __init__(self):
        self.books: Dict[str, Book] = {}
        self.categories: Set[str] = set()

    # Operaciones básicas
    def add_book(self, title: str, author: str, year: int, categories: List[str]) -> str:
        book_id = str(uuid.uuid4())
        cats = set(c.strip().lower() for c in categories if c.strip())
        book = Book(id=book_id, title=title.strip(), author=author.strip(), year=year, categories=cats)
        self.books[book_id] = book
        self.categories.update(cats)
        return book_id

    def remove_book(self, book_id: str) -> bool:
        if book_id in self.books:
            removed = self.books.pop(book_id)
            # actualizar categorías: reconstruir conjunto a partir de libros restantes
            self._rebuild_categories()
            return True
        return False

    def _rebuild_categories(self):
        self.categories = set()
        for b in self.books.values():
            self.categories.update(b.categories)

    def find_by_id(self, book_id: str) -> Optional[Book]:
        return self.books.get(book_id)

    def find_by_author(self, author_query: str) -> List[Book]:
        q = author_query.strip().lower()
        return [b for b in self.books.values() if q in b.author.lower()]

    def list_by_category(self, category: str) -> List[Book]:
        c = category.strip().lower()
        return [b for b in self.books.values() if c in b.categories]

    def report_all(self) -> List[Dict]:
        return [b.to_dict() for b in self.books.values()]

    # Reportería simple: mostrar conteos y ejemplos
    def summary(self) -> Dict:
        return {
            'total_books': len(self.books),
            'total_categories': len(self.categories),
            'categories': sorted(list(self.categories))[:50]
        }

# Funciones para medición de tiempos

def measure_time(func, *args, repeat: int = 1000):
    """Mide el tiempo promedio (en microsegundos) de ejecutar func(*args).

    Usa repeat para ejecutar varias veces (si la operación es muy rápida).
    """
    # Para evitar que costosas operaciones de creación distorsionen, asumimos
    # que func es una operación rápida (por ejemplo, búsqueda en diccionario).
    t0 = time.perf_counter()
    for _ in range(repeat):
        func(*args)
    t1 = time.perf_counter()
    total = t1 - t0
    avg_seconds = total / repeat
    return avg_seconds * 1e6  # microsegundos

# Generador de datos de prueba

authors_sample = ['Gabriel García Márquez', 'Isabel Allende', 'J. K. Rowling', 'J. R. R. Tolkien',
                  'Yuval Noah Harari', 'Malcolm Gladwell', 'Jane Austen', 'Stephen King']

titles_sample = ['Introducción a la programación', 'Algoritmos y estructuras', 'Cien años de soledad',
                 'Viaje al centro de la Tierra', 'Historia del tiempo', 'Prácticas de laboratorio']

categories_sample = ['ciencia', 'literatura', 'programación', 'historia', 'fantasía', 'novela', 'ensayo']

def generate_dummy_book(library: Library) -> str:
    title = random.choice(titles_sample) + ' ' + str(random.randint(1, 999))
    author = random.choice(authors_sample)
    year = random.randint(1950, 2024)
    cats = random.sample(categories_sample, k=random.randint(1, 3))
    return library.add_book(title, author, year, cats)

# Interfaz de consola

def print_menu():
    print('\n--- Biblioteca (Conjuntos y Mapas) ---')
    print('1. Agregar libro')
    print('2. Eliminar libro por ID')
    print('3. Buscar libro por ID')
    print('4. Buscar por autor')
    print('5. Listar por categoría')
    print('6. Reportería (todos los libros)')
    print('7. Resumen y conteos')
    print('8. Prueba de rendimiento (datos de ejemplo)')
    print('9. Salir')


def cli():
    lib = Library()

    while True:
        print_menu()
        opt = input('Seleccione una opción: ').strip()
        if opt == '1':
            title = input('Título: ')
            author = input('Autor: ')
            year = int(input('Año: '))
            cats = input('Categorías (separadas por coma): ').split(',')
            book_id = lib.add_book(title, author, year, cats)
            print(f'Libro agregado con ID: {book_id}')
        elif opt == '2':
            bid = input('ID del libro a eliminar: ').strip()
            ok = lib.remove_book(bid)
            print('Eliminado.' if ok else 'No se encontró el ID.')
        elif opt == '3':
            bid = input('ID del libro a buscar: ').strip()
            b = lib.find_by_id(bid)
            if b:
                print(b.to_dict())
            else:
                print('No se encontró el libro.')
        elif opt == '4':
            a = input('Nombre o parte del autor: ')
            res = lib.find_by_author(a)
            print(f'Se encontraron {len(res)} libros:')
            for r in res:
                print(r.to_dict())
        elif opt == '5':
            c = input('Categoría: ')
            res = lib.list_by_category(c)
            print(f'Se encontraron {len(res)} libros:')
            for r in res:
                print(r.to_dict())
        elif opt == '6':
            allb = lib.report_all()
            print(f'Total libros: {len(allb)}')
            for b in allb:
                print(b)
        elif opt == '7':
            s = lib.summary()
            print('Resumen:')
            print(s)
        elif opt == '8':
            n = int(input('¿Cuántos libros de prueba generar? (ej: 1000): '))
            print('Generando datos...')
            ids = []
            t0 = time.perf_counter()
            for _ in range(n):
                ids.append(generate_dummy_book(lib))
            t1 = time.perf_counter()
            print(f'Generación de {n} libros finalizada en { (t1-t0):.4f } segundos.')

            # Medición de búsquedas por ID (usar un ID existente y uno inexistente)
            existing_id = random.choice(ids)
            missing_id = str(uuid.uuid4())

            avg_existing = measure_time(lib.find_by_id, existing_id, repeat=2000)
            avg_missing = measure_time(lib.find_by_id, missing_id, repeat=2000)

            print(f'Tiempo promedio búsqueda por ID (existente): {avg_existing:.3f} µs')
            print(f'Tiempo promedio búsqueda por ID (no existente): {avg_missing:.3f} µs')

            # Medición búsqueda por autor
            sample_author = random.choice(authors_sample).split()[0]
            avg_author = measure_time(lib.find_by_author, sample_author, repeat=200)
            print(f'Tiempo promedio búsqueda por autor (partial match): {avg_author:.3f} µs')

            # Resumen tras prueba
            print('Resumen tras prueba: ', lib.summary())
        elif opt == '9':
            print('Saliendo. Guardar capturas para anexos si es necesario.')
            break
        else:
            print('Opción no válida. Intente nuevamente.')


if __name__ == '__main__':
    print('Ejecutable: biblioteca_conjuntos_mapas.py')
    print('Instrucciones: use las opciones del menú para interactuar. Para evidencias, use la opción 8.')
    cli()
